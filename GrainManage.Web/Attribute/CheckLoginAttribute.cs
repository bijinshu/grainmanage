using GrainManage.Common;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GrainManage.Web
{
    public class CheckLoginAttribute : Attribute, IAuthorizationFilter
    {
        private static readonly double cacheMinute = AppConfig.GetValue<double>(GlobalVar.CacheMinute);
        private static readonly List<string> pubUrls = new List<string>();
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
                    var userId = CookieUtil.Get<int>(cookies, GlobalVar.CookieName, GlobalVar.UserId);
                    var userName = CookieUtil.Get(cookies, GlobalVar.CookieName, GlobalVar.UserName);
                    var level = CookieUtil.Get<int>(cookies, GlobalVar.CookieName, GlobalVar.Level);
                    var token = CookieUtil.Get(cookies, GlobalVar.CookieName, GlobalVar.AuthToken);
                    if (userId > 0 && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(token))
                    {
                        var userKey = CacheKey.GetUserKey(userId);
                        var cacheClient = filterContext.HttpContext.RequestServices.GetService(typeof(ICache)) as ICache;
                        var userInfo = cacheClient.Get<UserInfo>(userKey);
                        var expiresAt = DateTime.Now.AddMinutes(cacheMinute);
                        if (userInfo != null && userInfo.UserName == userName && userInfo.Token == token && cacheClient.ExpireAt(userKey, expiresAt))
                        {
                            var values = filterContext.RouteData.Values;
                            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
                            if (level >= GlobalVar.MaxLevel ||
                                  pubUrls.Any(a => string.Equals(a, url, StringComparison.CurrentCultureIgnoreCase)) ||
                                userInfo.Urls.Any(a => string.Equals(a, url, StringComparison.CurrentCultureIgnoreCase)))
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
    }
}