using GrainManage.Web.Common;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using GrainManage.Web.Services;
using System.Text;
using DataBase.GrainManage.Models.Log;

namespace GrainManage.Web
{
    public class LogExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var logger = NLog.LogManager.GetLogger(HttpUtility.UrlDecode(filterContext.HttpContext.Request.Url.PathAndQuery, Encoding.UTF8));
            try
            {
                var errorMsg = ExceptionUtil.GetStackMessage(filterContext.Exception);
                logger.Error(errorMsg);
                var model = new ExceptionLog
                {
                    Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Url.AbsolutePath, Encoding.UTF8),
                    InputParameter = HttpUtil.GetInputPara(),
                    Message = errorMsg,
                    StackTrace = filterContext.Exception.StackTrace,
                    ClientIP = HttpUtil.RequestHostAddress,
                    CreatedAt = DateTime.Now
                };
                LogService.AddExceptionLog(model);
                if (filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = new NewtonsoftJsonResult() { Data = new BaseOutput { msg = errorMsg }, IncludeNotValid = true };
                }
            }
            catch (Exception e)
            {
                logger.Fatal(ExceptionUtil.GetStackMessage(e));
            }
        }
    }
}