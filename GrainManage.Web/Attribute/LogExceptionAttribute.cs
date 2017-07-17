using GrainManage.Web.Common;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web
{
    public class LogExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
        public void OnException(ExceptionContext filterContext)
        {
            var logger = NLog.LogManager.GetLogger(filterContext.HttpContext.Request.Url.PathAndQuery);
            try
            {
                var msg = ExceptionUtil.GetStackMessage(filterContext.Exception);
                logger.Error(msg);
                var db = new GrainManage.Dal.GrainManageDB();
                var model = new
                {
                    Path = logger.Name,
                    //InputParameter = GetJson(filterContext.HttpContext.Request.Form.GetValues(0)) ?? string.Empty,
                    Message = msg,
                    StackTrace = filterContext.Exception.StackTrace,
                    ClientIP = HttpUtil.RequestHostAddress,
                    CreateTime = DateTime.Now
                };
                db.Execute("insert into log_exception(Path,InputParameter,Message,StackTrace,ClientIP,CreateTime) values(@Path,@InputParameter,@Message,@StackTrace,@ClientIP,@CreateTime)", model);
            }
            catch (Exception e)
            {
                logger.Fatal(e.Message);
            }
        }
        private string GetJson(object obj)
        {
            if (obj != null)
            {
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
            }
            return string.Empty;
        }
    }
}