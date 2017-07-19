using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Web;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Linq;

namespace GrainManage.Web
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        GrainManage.Dal.GrainManageDB db = new GrainManage.Dal.GrainManageDB();
        private const string name = "log-action";
        private string[] Methods { get { return (AppConfig.GetValue("LogMethods") ?? string.Empty).Split(','); } }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Methods.Any(s => string.Equals(s.Trim(), filterContext.HttpContext.Request.HttpMethod, StringComparison.CurrentCultureIgnoreCase)))
            {
                var sql = "insert into log_action(UserName,Path,ClientIP,Method,StartTime) values(@UserName,@Path,@ClientIP,@Method,@StartTime);select last_insert_id()";
                var headers = filterContext.HttpContext.Request.Headers;
                ActionLog model = new ActionLog();
                model.Path = filterContext.HttpContext.Request.Url.PathAndQuery;
                model.ClientIP = HttpUtil.RequestHostAddress;
                model.UserName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
                model.Method = filterContext.HttpContext.Request.HttpMethod;
                model.StartTime = DateTime.Now;
                model.Id = db.ExecuteScalar<int>(sql, model);
                headers.Set(name, string.Format("{0},{1}", model.Id.ToString(), model.StartTime.ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Methods.Any(s => string.Equals(s.Trim(), filterContext.HttpContext.Request.HttpMethod, StringComparison.CurrentCultureIgnoreCase)))
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
                var model = new { Id = int.Parse(logAction[0]), EndTime = now, TimeSpan = now - DateTime.Parse(logAction[1]), Status = msg };
                db.Execute("update log_action set Status=@Status,EndTime=@EndTime,TimeSpan=@TimeSpan where Id=@Id ", model);
            }
        }
    }
}