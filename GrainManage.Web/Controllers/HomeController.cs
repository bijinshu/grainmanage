using GrainManage.Web.Common;
using GrainManage.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.BM;

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
        public ActionResult PerfectComp(string Name, string Address)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            if (string.IsNullOrEmpty(Name))
            {
                SetResponse(s => s.CompanyNameEmpty, result);
            }
            else if (repo.GetFiltered(f => f.Name == Name).Any())
            {
                SetResponse(s => s.CompanyNameExisted, result);
            }
            else
            {
                using (var trans = repo.UnitOfWork.BeginTransaction())
                {
                    var model = repo.Add(new Company { Name = Name, Address = Address ?? string.Empty, UserId = UserId });
                    result.data = model.Id;
                    if (model.Id > 0)
                    {
                        var userRepo = GetRepo<User>();
                        var user = userRepo.Get(UserId);
                        user.CompId = model.Id;
                        userRepo.UnitOfWork.SaveChanges();
                    }
                    trans.Commit();
                    SetResponse(s => s.Success, result);
                }
            }

            return JsonNet(result, true);
        }
    }
}