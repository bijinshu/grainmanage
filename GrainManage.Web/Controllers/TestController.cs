using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrainManage.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult PathCombine(string u)
        {
            return Content(UrlVar.GetUrl(u));
        }
        [AllowAnonymous]
        public IActionResult Conn()
        {
            return Content(AppConfig.GetValue("ImagePath"));
        }
        [AllowAnonymous]
        public IActionResult Ip()
        {
            var ip = $"X-Forwarded-For:{HttpUtil.GetHeader(Request, "X-Forwarded-For")}," +
                $"X-Real-IP:{HttpUtil.GetHeader(Request, "X-Real-IP")}," +
                $"Remote_Addr:{HttpUtil.GetHeader(Request, "Remote_Addr")}," +
                $"Host:{Request.Host.Host}";
            return Content(ip);
        }
        [AllowAnonymous]
        public IActionResult CurrentDateTime()
        {
            return Content(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}