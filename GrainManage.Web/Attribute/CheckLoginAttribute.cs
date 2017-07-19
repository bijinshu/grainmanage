using System;
using System.Web.Mvc;
using System.Linq;
using GrainManage.Web.Common;
using System.Web;
using GrainManage.Web;
using GrainManage.Web.Models;
using GrainManage.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GrainManage.Web
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        private static readonly double cacheMinute = AppConfig.GetValue<double>(GlobalVar.CacheMinute);
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                if (!string.IsNullOrEmpty(CookieUtil.GetCookie(GlobalVar.CookieName)))
                {
                    var userId = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserId);
                    var userName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
                    var token = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken);
                    if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(token))
                    {
                        var userKey = CacheKey.GetUserKey(userId);
                        var cacheClient = DependencyResolver.Current.GetService<ICache>();
                        var cachedSafeInfo = cacheClient.Get<UserInfo>(userKey);
                        var expiresAt = DateTime.Now.AddMinutes(cacheMinute);
                        if (cachedSafeInfo != null && cachedSafeInfo.UserName == userName && cachedSafeInfo.Token == token && cacheClient.ExpireAt(userKey, expiresAt))
                        {
                            return;
                        }
                    }
                }
                if (filterContext.HttpContext.Request.HttpMethod == "GET")
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = string.Format("<script>window.location='{0}';</script>", HttpUtil.GetUrl("Account/SignIn/")),
                        ContentType = "text/html; charset=utf-8"
                    };
                }
                else
                {
                    var mes = GrainManage.Message.CacheMessage.Get<StatusCode>(s => s.IdentityFailed);
                    filterContext.Result = new NewtonsoftJsonResult { Data = new BaseOutput { code = mes.Code, msg = mes.Description, data = HttpUtil.GetUrl("Account/SignIn/") } };
                }
            }
        }
    }
}