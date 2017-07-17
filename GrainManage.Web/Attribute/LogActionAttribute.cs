using DataBase.GrainManage.Models;
using GrainManage.Web;
using GrainManage.Web.Common;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace GrainManage.Web
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        GrainManage.Dal.GrainManageDB db = new GrainManage.Dal.GrainManageDB();
        private const string name = "log-action";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sql = "insert into log_action(UserId,ActionName,ClientIP,StartTime) values(@UserId,@ActionName,@ClientIP,@StartTime);select last_insert_id()";
            var headers = filterContext.HttpContext.Request.Headers;
            ActionLog model = new ActionLog();
            model.ActionName = string.Format("{0}.{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
            model.ClientIP = HttpUtil.RequestHostAddress;
            model.UserId = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
            model.StartTime = DateTime.Now;
            model.Id = db.ExecuteScalar<int>(sql, model);
            headers.Add(name, string.Format("{0},{1}", model.Id.ToString(), model.StartTime.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logAction = filterContext.HttpContext.Request.Headers.Get(name).Split(',');
            var now = DateTime.Now;
            var model = new { Id = int.Parse(logAction[0]), EndTime = now, TimeSpan = now - DateTime.Parse(logAction[1]) };
            db.Execute("update log_action set EndTime=@EndTime,TimeSpan=@TimeSpan where Id=@Id ", model);
        }
    }
}