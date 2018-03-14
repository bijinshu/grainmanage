using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}