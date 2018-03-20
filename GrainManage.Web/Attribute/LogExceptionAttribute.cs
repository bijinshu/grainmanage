using DataBase.GrainManage.Models.Log;
using GrainManage.Web.Common;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text;
using System.Web;

namespace GrainManage.Web
{
    public class LogExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var logger = NLog.LogManager.GetLogger(HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8));
            try
            {
                var errorMsg = ExceptionUtil.GetStackMessage(filterContext.Exception);
                logger.Error(errorMsg);
                var model = new ExceptionLog
                {
                    Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8),
                    Para = HttpUtil.GetInputPara(filterContext.HttpContext.Request),
                    Message = errorMsg,
                    StackTrace = filterContext.Exception.StackTrace,
                    ClientIP = HttpUtil.GetRequestHostAddress(filterContext.HttpContext.Request),
                    CreatedAt = DateTime.Now
                };
                LogService.AddExceptionLog(model);
                filterContext.ExceptionHandled = true;
                if (filterContext.HttpContext.Request.Method == "POST")
                {
                    filterContext.Result = new JsonResult(new BaseOutput { msg = errorMsg });
                }
                else
                {
                    filterContext.Result = new ContentResult() { Content = errorMsg };
                }
            }
            catch (Exception e)
            {
                var stackMsg = ExceptionUtil.GetStackMessage(e);
                logger.Fatal(stackMsg);
                filterContext.Result = new JsonResult(new BaseOutput { msg = stackMsg });
            }
        }
    }
}