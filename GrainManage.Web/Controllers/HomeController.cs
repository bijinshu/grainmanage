using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Web.Common;
using GrainManage.Web.Models.Company;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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