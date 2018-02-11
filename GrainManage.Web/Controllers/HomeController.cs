using GrainManage.Web.Common;
using GrainManage.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GrainManage.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(CurrentUser);
        }
        public ActionResult MenuTree()
        {
            var menuList = CommonService.GetMenus();
            if (!IsSuperAdmin)
            {
                TreeUtil.RemoveNotValid(menuList, CurrentUser.Auths);
            }
            TreeUtil.SetParent(menuList);
            return JsonNet(menuList, true);
        }
        [AllowAnonymous]
        public ActionResult GetHeaders()
        {
            return Content(string.Join("\r\n", Request.Headers.Select(s => string.Format("{0}:{1}", s.Key, s.Value))));
        }
    }
}