using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Helpers;

namespace GrainManage.Web.Controllers
{
    public class WeixinJSSDKController : BaseController
    {
        public IActionResult Index()
        {
            var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(AppId, AppSecret, Request.AbsoluteUri());
            return Json(jssdkUiPackage);
        }
    }
}