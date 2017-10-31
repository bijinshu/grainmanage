using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Web.Models;
using GrainManage.Core;
using DataBase.GrainManage.Models;
using GrainManage.Web.Common;
using NLog;

namespace GrainManage.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info(Request.ContentType);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
