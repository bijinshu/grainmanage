using GrainManage.Web.Common;
using GrainManage.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

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
    }
}