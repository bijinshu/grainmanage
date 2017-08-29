using Newtonsoft.Json;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web
{
    public class NewtonsoftJsonResult : ActionResult
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }
        public bool IncludeNotValid { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context is null");
            }

            HttpResponseBase response = context.HttpContext.Response;

            //设置媒体类型和编码方式   
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;
            response.ContentEncoding = this.ContentEncoding == null ? System.Text.Encoding.UTF8 : this.ContentEncoding;

            if (Data != null)
            {
                response.Write(IncludeNotValid ? JsonConvert.SerializeObject(this.Data) : JsonConvert.SerializeObject(this.Data, settings));
            }
        }
    }
}