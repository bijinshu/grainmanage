using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Cache;
using GrainManage.Web.Common;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GrainManage.Web
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        private const string name = "log-action";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies;
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (UrlCache.IsUrlExisted(url))
            {
                var headers = filterContext.HttpContext.Request.Headers;
                ActionLog model = new ActionLog();
                model.Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8);
                model.ClientIP = HttpUtil.GetRequestHostAddress(filterContext.HttpContext.Request);
                model.UserName = CookieUtil.GetCookie(cookies, GlobalVar.CookieName, GlobalVar.UserName);
                model.Method = filterContext.HttpContext.Request.Method;
                model.Para = HttpUtil.GetInputPara(filterContext.HttpContext.Request);
                model.Level = CookieUtil.GetCookie<int>(cookies, GlobalVar.CookieName, GlobalVar.Level);
                model.StartTime = DateTime.Now;
                model.Id = LogService.AddActionLog(model);
                headers.Add(name, string.Format("{0},{1}", model.Id.ToString(), model.StartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (UrlCache.IsUrlExisted(url))
            {
                var logAction = filterContext.HttpContext.Request.Headers[name].First().Split(',');
                var now = DateTime.Now;
                var msg = string.Empty;
                JsonResult result = null;
                if (filterContext.HttpContext.Request.Method == "POST" && (result = filterContext.Result as JsonResult) != null)
                {
                    var baseOutput = result.Value as BaseOutput;
                    if (baseOutput != null)
                    {
                        msg = baseOutput.msg;
                    }
                }
                var model = new { Id = int.Parse(logAction[0]), EndTime = now, TimeSpan = now - DateTime.Parse(logAction[1]), Status = msg ?? string.Empty };
                LogService.UpdateActionLog(model);
            }
        }
    }
}