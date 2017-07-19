using GrainManage.Web.Common;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    InputParameter = filterContext.HttpContext.Request.HttpMethod == "POST" ? GetJson(GetFormData(filterContext.HttpContext.Request.Form)) : string.Empty,
                    Message = msg,
                    StackTrace = filterContext.Exception.StackTrace,
                    ClientIP = HttpUtil.RequestHostAddress,
                    CreateTime = DateTime.Now
                };
                db.Execute("insert into log_exception(Path,InputParameter,Message,StackTrace,ClientIP,CreateTime) values(@Path,@InputParameter,@Message,@StackTrace,@ClientIP,@CreateTime)", model);
                if (filterContext.HttpContext.Request.HttpMethod == "POST")
                {
                    filterContext.Result = new NewtonsoftJsonResult() { Data = new BaseOutput { msg = msg } };
                }
            }
            catch (Exception e)
            {
                logger.Fatal(ExceptionUtil.GetStackMessage(e));
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
        private Dictionary<string, string> GetFormData(NameValueCollection form)
        {
            if (form != null && form.Count > 0)
            {
                var dic = new Dictionary<string, string>();
                foreach (var name in form.AllKeys)
                {
                    dic[name] = form[name];
                }
                return dic;
            }
            return null;
        }
    }
}