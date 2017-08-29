using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Web;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using GrainManage.Web.Services;
using System.Text;

namespace GrainManage.Web
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        GrainManage.Dal.GrainManageDB db = new GrainManage.Dal.GrainManageDB();
        private const string name = "log-action";
        private static readonly List<string> urlList = new List<string>();
        static LogActionAttribute()
        {
            var path = HttpContext.Current.Server.MapPath("~/url.txt");
            if (System.IO.File.Exists(path))
            {
                var lines = System.IO.File.ReadAllLines(path);
                urlList.AddRange(lines.Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()));
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (urlList.Any(s => string.Equals(s, url, StringComparison.CurrentCultureIgnoreCase)))
            {
                var headers = filterContext.HttpContext.Request.Headers;
                ActionLog model = new ActionLog();
                model.Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Url.AbsolutePath, Encoding.UTF8);
                model.ClientIP = HttpUtil.RequestHostAddress;
                model.UserName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
                model.Method = filterContext.HttpContext.Request.HttpMethod;
                model.Para = HttpUtil.GetInputPara();
                model.Level = CookieUtil.GetCookie<int>(GlobalVar.CookieName, GlobalVar.Level);
                model.StartTime = DateTime.Now;
                model.Id = LogService.AddActionLog(model);
                headers.Set(name, string.Format("{0},{1}", model.Id.ToString(), model.StartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (urlList.Any(s => string.Equals(s, url, StringComparison.CurrentCultureIgnoreCase)))
            {
                var logAction = filterContext.HttpContext.Request.Headers.Get(name).Split(',');
                var now = DateTime.Now;
                NewtonsoftJsonResult result = null;
                var msg = string.Empty;
                if (filterContext.HttpContext.Request.HttpMethod == "POST" && (result = filterContext.Result as NewtonsoftJsonResult) != null)
                {
                    var baseOutput = result.Data as BaseOutput;
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