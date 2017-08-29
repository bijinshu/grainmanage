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
using System.Reflection;

namespace GrainManage.Web
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        private static readonly double cacheMinute = AppConfig.GetValue<double>(GlobalVar.CacheMinute);
        private static readonly List<string> pubUrls = new List<string>();
        static CheckLoginAttribute()
        {
            var allUrls = new List<string>();
            foreach (var item in typeof(UrlVar).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                var url = item.GetValue(null) as string;
                if (!string.IsNullOrEmpty(url))
                {
                    allUrls.Add(url);
                    if (item.GetCustomAttributes<CommonAttribute>().Any())
                    {
                        pubUrls.Add(url);
                    }
                }
            }
            UrlVar.EnableRawUrl();
            var path = HttpContext.Current.Server.MapPath("~/url_all.txt");
            System.IO.File.WriteAllLines(path, allUrls);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                if (!string.IsNullOrEmpty(CookieUtil.GetCookie(GlobalVar.CookieName)))
                {
                    var userId = CookieUtil.GetCookie<int>(GlobalVar.CookieName, GlobalVar.UserId);
                    var userName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
                    var level = CookieUtil.GetCookie<int>(GlobalVar.CookieName, GlobalVar.Level);
                    var token = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken);
                    if (userId > 0 && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(token))
                    {
                        var userKey = CacheKey.GetUserKey(userId);
                        var cacheClient = DependencyResolver.Current.GetService<ICache>();
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
                if (filterContext.HttpContext.Request.HttpMethod == "GET")
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
                    filterContext.Result = new NewtonsoftJsonResult { Data = new BaseOutput { code = mes.Code, msg = mes.Description, data = UrlVar.User_SignIn } };
                }
            }
        }
    }
}