using Newtonsoft.Json;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web
{
    public class NewtonsoftJsonResult : ActionResult
    {
        // Summary:
        //     Gets or sets the content encoding.
        //
        // Returns:
        //     The content encoding.
        public Encoding ContentEncoding { get; set; }
        //
        // Summary:
        //     Gets or sets the type of the content.
        //
        // Returns:
        //     The type of the content.
        public string ContentType { get; set; }
        //
        // Summary:
        //     Gets or sets the data.
        //
        // Returns:
        //     The data.
        public object Data { get; set; }

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
                response.Write(JsonConvert.SerializeObject(this.Data));
            }
        }
    }
}