using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace GrainManage.Web
{
    public class CheckLoginAttribute : Attribute, IAuthorizationFilter
    {
        private static readonly double cacheMinute = AppConfig.GetValue<double>(GlobalVar.CacheMinute);
        private static readonly List<string> pubUrls = new List<string>();
        private static readonly object lockObj = new object();
        static CheckLoginAttribute()
        {
            foreach (var item in typeof(UrlVar).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                var url = item.GetValue(null) as string;
                if (!string.IsNullOrEmpty(url))
                {
                    if (item.GetCustomAttributes<CommonAttribute>().Any())
                    {
                        pubUrls.Add(url);
                    }
                }
            }
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!filterContext.ActionDescriptor.FilterDescriptors.Any(f => f.Filter?.GetType() == typeof(AllowAnonymousFilter)))
            {
                var cookies = filterContext.HttpContext.Request.Cookies;
                if (!string.IsNullOrEmpty(CookieUtil.Get(cookies, GlobalVar.CookieName)))
                {
                    var cookieUserInfo = UserUtil.GetFromCookie(cookies);
                    if (cookieUserInfo != null && cookieUserInfo.UserId > 0 && !string.IsNullOrEmpty(cookieUserInfo.Token))
                    {
                        var userKey = CacheKey.GetUserKey(cookieUserInfo.UserId, cookieUserInfo.Agent);
                        var cacheClient = filterContext.HttpContext.RequestServices.GetService(typeof(ICache)) as ICache;
                        var userInfo = cacheClient.Get<UserInfo>(userKey);
                        var expiresAt = DateTime.Now.AddMinutes(cacheMinute);
                        if (cookieUserInfo.Agent == 0)
                        {
                            if (userInfo != null && userInfo.Token == cookieUserInfo.Token && cacheClient.ExpireAt(userKey, expiresAt) &&
                                AllowAccess(filterContext.RouteData.Values, userInfo))
                            {
                                return;
                            }
                        }
                        else if (cookieUserInfo.Agent == 1 && DateTime.TryParse(cookieUserInfo.ExpiredAt, out DateTime expireAt) && expireAt >= DateTime.Now)
                        {
                            if (userInfo == null)
                            {
                                lock (lockObj)
                                {
                                    if (userInfo == null)
                                    {
                                        userInfo = GetUserInfo(filterContext, cookieUserInfo, cacheClient);
                                    }
                                }
                            }
                            if (userInfo != null && AllowAccess(filterContext.RouteData.Values, userInfo))
                            {
                                return;
                            }
                        }
                    }
                }
                if (filterContext.HttpContext.Request.Method == "GET")
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = string.Format("<script>window.location='{0}';</script>", UrlVar.User_SignIn),
                        ContentType = "text/html; charset=utf-8"
                    };
                }
                else
                {
                    var mes = GrainManage.Message.CacheMessage.Get<StatusCode>(s => s.IdentityFailed);
                    filterContext.Result = new JsonResult(new BaseOutput { code = mes.Code, msg = mes.Description, data = UrlVar.User_SignIn });
                }
            }
        }
        private static bool AllowAccess(Microsoft.AspNetCore.Routing.RouteValueDictionary values, UserInfo userInfo)
        {
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (userInfo.Level >= GlobalVar.MaxLevel ||
                  pubUrls.Any(a => string.Equals(a, url, StringComparison.CurrentCultureIgnoreCase)) ||
                userInfo.Urls.Any(a => string.Equals(a, url, StringComparison.CurrentCultureIgnoreCase)))
            {
                return true;
            }
            return false;
        }
        private static UserInfo GetUserInfo(AuthorizationFilterContext filterContext, CookieUserInfo cookieUserInfo, ICache cacheClient)
        {
            UserInfo userInfo = null;
            try
            {
                var userRepo = filterContext.HttpContext.RequestServices.GetService(typeof(IRepository<User>)) as IRepository<User>;
                var account = userRepo.GetFiltered(f => f.Id == cookieUserInfo.UserId).FirstOrDefault();
                if (account != null)
                {
                    var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                    userInfo = new UserInfo
                    {
                        UserId = account.Id,
                        CompId = account.CompId,
                        UserName = account.UserName,
                        Roles = account.Roles.Split(',').Select(s => int.Parse(s)).ToArray(),
                        Token = cookieUserInfo.Token,
                        ExpiredAt = cookieUserInfo.ExpiredAt,
                        LoginIP = HttpUtil.GetRequestHostAddress(filterContext.HttpContext.Request)
                    };
                    userInfo.Level = RoleService.GetMaxLevel(userInfo.Roles);
                    userInfo.Auths = CommonService.GetAuths(userInfo.Roles);
                    userInfo.Urls = CommonService.GetUrls(userInfo.Roles);
                    cacheClient.Set(CacheKey.GetUserKey(cookieUserInfo.UserId, cookieUserInfo.Agent), userInfo, expireAt);
                }
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetLogger(HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8));
                try
                {
                    logger.Error(ExceptionUtil.GetStackMessage(e));
                    var model = new ExceptionLog
                    {
                        Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8),
                        Para = HttpUtil.GetInputPara(filterContext.HttpContext.Request),
                        Message = ExceptionUtil.GetInnerestMessage(e),
                        StackTrace = e.StackTrace,
                        ClientIP = HttpUtil.GetRequestHostAddress(filterContext.HttpContext.Request),
                        CreatedAt = DateTime.Now
                    };
                    LogService.AddExceptionLog(model);
                }
                catch (Exception ee)
                {
                    logger.Fatal(ExceptionUtil.GetStackMessage(ee));
                }
            }
            return userInfo;
        }
    }
}