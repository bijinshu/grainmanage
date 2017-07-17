using System;
using System.Web.Mvc;
using System.Linq;
using GrainManage.Web.Util;
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
                    var userName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
                    var token = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken);
                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(token))
                    {
                        var safeInfoKey = CacheKey.GetSafeInfoKey(userName);
                        var cacheClient = DependencyResolver.Current.GetService<GrainManage.Common.ICache>();
                        var cachedSafeInfo = cacheClient.Get<SafeInfo>(safeInfoKey);
                        var expiresAt = DateTime.Now.AddMinutes(cacheMinute);
                        if (cachedSafeInfo != null && cachedSafeInfo.Token == token && cacheClient.ExpireAt(safeInfoKey, expiresAt))
                        {
                            return;
                        }
                    }
                }
                filterContext.Result = new ContentResult()
                {
                    Content = string.Format("<script>window.location='{0}';</script>", HttpUtil.GetUrl("Account/SignIn/")),
                    ContentType = "text/html; charset=utf-8"
                };
            }
        }
    }
}