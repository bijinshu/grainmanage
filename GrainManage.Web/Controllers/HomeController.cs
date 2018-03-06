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
using GrainManage.Common;

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

        public ActionResult PerfectComp(string Name, string Address)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            if (string.IsNullOrEmpty(Name))
            {
                SetResponse(s => s.CompanyNameEmpty, result);
            }
            else if (repo.GetFiltered(f => f.Name == Name && f.UserId != UserId).Any())
            {
                SetResponse(s => s.CompanyNameExisted, result);
            }
            else
            {
                var userRepo = GetRepo<User>();
                var comp = repo.GetFiltered(f => f.UserId == UserId, true).FirstOrDefault();
                if (comp == null)
                {
                    using (var trans = repo.UnitOfWork.BeginTransaction())
                    {
                        comp = repo.Add(new Company { Name = Name, Address = Address ?? string.Empty, UserId = UserId });
                        var user = userRepo.Get(UserId);
                        user.CompId = comp.Id;
                        userRepo.UnitOfWork.SaveChanges();
                        if (comp != null && comp.Id > 0)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                }
                else
                {
                    comp.Name = Name;
                    comp.Address = Address ?? string.Empty;
                    var user = userRepo.Get(UserId);
                    user.CompId = comp.Id;
                    userRepo.UnitOfWork.SaveChanges();
                }
                if (comp != null && comp.Id > 0)
                {
                    var userInfo = CurrentUser;
                    userInfo.CompId = comp.Id;
                    var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                    Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId), userInfo, expireAt);
                    result.data = comp.Id;
                }
                SetResponse(s => s.Success, result);
            }

            return JsonNet(result, true);
        }
    }
}