using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Common;
using GrainManage.Encrypt;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace GrainManage.Web.Controllers
{
    [AllowAnonymous]
    public class OAuth2Controller : BaseController
    {
        public ActionResult Index(string returnUrl)
        {
            var redirectUrl = "http://weixin.bijinshu.cn/oauth2/UserInfoCallback?returnUrl=" + returnUrl.UrlEncode();
            var authorizeUrl = OAuthApi.GetAuthorizeUrl(AppId, redirectUrl, DateTime.Now.Millisecond.ToString(), OAuthScope.snsapi_userinfo);
            return Content(authorizeUrl);
        }

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户最初尝试进入的页面</param>
        /// <returns></returns>
        public ActionResult UserInfoCallback(string code, string state, string returnUrl)
        {
            var result = new BaseOutput();
            var logModel = new LoginLog { LoginIP = HttpUtil.GetClientIP(Request), TypeId = 1 };
            var tokenResult = OAuthApi.GetAccessToken(AppId, AppSecret, code);
            if (tokenResult.errcode == ReturnCode.请求成功)
            {
                var weixinUserInfo = OAuthApi.GetUserInfo(tokenResult.access_token, tokenResult.openid);
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.OpenId == weixinUserInfo.openid).FirstOrDefault();
                if (account == null) //不存在的话自动建立账户
                {
                    var model = new User
                    {
                        UserName = weixinUserInfo.openid,
                        OpenId = weixinUserInfo.openid,
                        Roles = GlobalVar.Role_User.ToString(),
                        CreatedAt = DateTime.Now,
                        CreatedBy = -1,
                        Status = Status.Enabled
                    };
                    SetEmptyIfNull(model);
                    account = repo.Add(model);
                }
                if (account != null && account.Id > 0)
                {
                    if (account.Status == Status.Enabled)
                    {
                        var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                        var userInfo = new UserInfo
                        {
                            UserId = account.Id,
                            CompId = account.CompId,
                            UserName = account.UserName,
                            Roles = account.Roles.Split(',').Select(s => int.Parse(s)).ToArray(),
                            Token = RandomGenerator.Next(20),
                            ExpiredAt = expireAt.ToString("yyyy-MM-dd HH:mm:ss"),
                            LoginIP = HttpUtil.GetClientIP(Request)
                        };
                        userInfo.Level = RoleService.GetMaxLevel(userInfo.Roles);
                        userInfo.Auths = CommonService.GetAuths(userInfo.Roles);
                        userInfo.Urls = CommonService.GetUrls(userInfo.Roles);
                        var agent = string.IsNullOrEmpty(returnUrl) ? 0 : 1;
                        Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId, agent), userInfo, expireAt);
                        UserUtil.WriteToCookie(Response.Cookies, userInfo, agent);
                        logModel.Level = userInfo.Level;
                        SetResponse(s => s.Success, result);
                    }
                    else
                    {
                        SetResponse(s => s.UserForbidden, result);
                    }
                }
                logModel.UserName = account == null || string.IsNullOrEmpty(account.UserName) ? weixinUserInfo.openid : account.UserName;
                logModel.Status = result.msg;
            }
            else
            {
                logModel.Status = tokenResult.errmsg;
            }
            LogService.AddLoginLog(logModel);
            return result.code == 1 ? Redirect(returnUrl) : JsonNet(result);
        }

        /// <summary>
        /// OAuthScope.snsapi_base方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户最初尝试进入的页面</param>
        /// <returns></returns>
        public ActionResult BaseCallback(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != HttpContext.Session.GetString("State"))
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                //建议用完之后就清空，将其一次性使用
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            //通过，用code换取access_token
            var result = OAuthApi.GetAccessToken(AppId, AppSecret, code);
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            HttpContext.Session.SetString("OAuthAccessTokenStartTime", DateTime.Now.ToString());
            HttpContext.Session.SetString("OAuthAccessToken", result.ToJson());

            //因为这里还不确定用户是否关注本微信，所以只能试探性地获取一下
            OAuthUserInfo userInfo = null;
            try
            {
                //已关注，可以得到详细信息
                userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }


                ViewData["ByBase"] = true;
                return View("UserInfoCallback", userInfo);
            }
            catch (ErrorJsonResultException ex)
            {
                //未关注，只能授权，无法得到详细信息
                //这里的 ex.JsonResult 可能为："{\"errcode\":40003,\"errmsg\":\"invalid openid\"}"
                return Content("用户已授权，授权Token：" + result);
            }
        }
    }
}