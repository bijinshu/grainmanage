using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class RoleController : BaseController
    {
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var roleRepo = GetRepo<Role>();
            int total = 0;
            Expression<Func<Role, bool>> myFilter = ExpressionBuilder.Where<Role>(f => f.Level < Level);
            if (!string.IsNullOrEmpty(input.Name))
            {
                myFilter = myFilter.And(f => f.Name.Contains(input.Name));
            }
            var list = roleRepo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter).ToList();
            result.total = total;
            var dtoList = MapTo<List<RoleDto>>(list);
            result.data = dtoList;
            if (dtoList.Any())
            {
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result,true);
        }
        public ActionResult New(RoleDto input)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Role>();
            if (input.Level >= Level)
            {
                SetResponse(s => s.AddRoleLevelNotEnough, result);
            }
            else if (!repo.GetFiltered(f => f.Name == input.Name).Any())
            {
                var model = MapTo<Role>(input);
                if (!IsSuperAdmin)
                {
                    model.Auths = string.Join(",", input.Auths.Intersect(CurrentUser.Auths));
                }
                model.Remark = model.Remark ?? string.Empty;
                model = repo.Add(model);
                result.data = model.Id;
                if (model.Id > 0)
                {
                    SetResponse(s => s.Success, input, result);
                }
                else
                {
                    SetResponse(s => s.InsertFailed, input, result);
                }
            }
            else
            {
                SetResponse(s => s.RoleExisted, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult Edit(RoleDto input)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Role>();
            if (input.Level >= Level)
            {
                SetResponse(s => s.EditRoleLevelNotEnough, result);
            }
            else if (!repo.GetFiltered(f => f.Name == input.Name && f.Id != input.Id).Any())
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                if (!IsSuperAdmin)
                {
                    model.Auths = string.Join(",", input.Auths.Intersect(CurrentUser.Auths));
                }
                model.Name = input.Name;
                model.Level = input.Level;
                model.Remark = input.Remark ?? string.Empty;
                model.Auths = input.Auths != null && input.Auths.Any() ? string.Join(",", input.Auths) : string.Empty;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.RoleExisted, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult Delete(int roleId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Role>();
            var model = repo.GetFiltered(f => f.Id == roleId).FirstOrDefault();
            if (model != null)
            {
                if (model.Level >= Level)
                {
                    SetResponse(s => s.DelRoleLevelNotEnough, result);
                }
                else
                {
                    repo.Delete(model);
                    SetResponse(s => s.Success, result);
                }
            }
            else
            {
                SetResponse(s => s.DeleteFailed, result);
            }
            return JsonNet(result);
        }
        public ActionResult GetRoleList()
        {
            var result = new BaseOutput();
            var roleRepo = GetRepo<Role>();
            var roles = roleRepo.GetFiltered(f => f.Level < Level).Select(s => new { value = s.Id, text = s.Name }).ToList();
            if (roles.Any())
            {
                result.data = roles;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
    }
}