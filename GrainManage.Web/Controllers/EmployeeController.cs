using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Core;
using GrainManage.Encrypt;
using GrainManage.Web.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var userRepo = GetRepo<User>();
            var employee = GlobalVar.Role_Employee.ToString();
            Expression<Func<User, bool>> myFilter = ExpressionBuilder.Where<User>(f => f.CreatedBy == UserId && f.Roles == employee);
            if (!string.IsNullOrEmpty(input.UserName))
            {
                myFilter = myFilter.And(f => f.UserName.Contains(input.UserName));
            }
            if (!string.IsNullOrEmpty(input.RealName))
            {
                myFilter = myFilter.And(f => f.RealName.Contains(input.RealName));
            }
            if (!string.IsNullOrEmpty(input.Mobile))
            {
                myFilter = myFilter.And(f => f.Mobile.Contains(input.Mobile));
            }
            if (input.Status.HasValue)
            {
                myFilter = myFilter.And(f => f.Status == input.Status);
            }
            var now = DateTime.Now;
            var list = userRepo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false).ToList();
            if (list.Any())
            {
                result.total = total;
                var dtoList = MapTo<List<UserDto>>(list);
                var roleRepo = GetRepo<Role>();
                var roleIdList = dtoList.SelectMany(s => s.Roles).Distinct().ToList();
                var roleList = roleRepo.GetFiltered(f => roleIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                var compRepo = GetRepo<Company>();
                var compIdList = list.Select(s => s.CompId).Distinct().ToList();
                var compList = compRepo.GetFiltered(f => compIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                foreach (var item in dtoList)
                {
                    item.Pwd = null;
                    var roleNames = string.Join(",", roleList.Where(f => item.Roles.Contains(f.Id)).Select(s => s.Name));
                    item.RoleNames = roleNames;
                    var comp = compList.FirstOrDefault(f => f.Id == item.CompId);
                    if (comp != null)
                    {
                        item.CompName = comp.Name;
                    }
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result, true);
        }
        public ActionResult New(UserDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var currentUser = CurrentUser;
            var repo = GetRepo<User>();
            if (currentUser.CompId < 0)
            {
                SetResponse(s => s.CompanyNotFullFill, input, result);
            }
            else if (string.IsNullOrEmpty(input.UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Pwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.UserName == input.UserName).Any())
            {
                SetResponse(s => s.NameExist, input, result);
            }
            else
            {
                if (currentUser.CompId > 0)
                {
                    var now = DateTime.Now;
                    var model = MapTo<User>(input);
                    model.Pwd = SHAEncrypt.SHA1(input.Pwd);
                    model.Roles = GlobalVar.Role_Employee.ToString();
                    model.CompId = currentUser.CompId;
                    model.CreatedBy = currentUser.UserId;
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
                else if (currentUser.CompId < 0)
                {
                    SetResponse(s => s.NotPerfectShopInfo, input, result);
                }
                else
                {
                    SetResponse(s => s.NotShopAdmin, input, result);
                }
            }
            return JsonNet(result);
        }
        public ActionResult Edit(UserDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<User>();
            var currentUser = CurrentUser;
            if (currentUser.CompId < 0)
            {
                SetResponse(s => s.CompanyNotFullFill, input, result);
            }
            else if (repo.GetFiltered(f => f.UserName == input.UserName && f.Id != input.Id).Any())
            {
                SetResponse(s => s.NameExist, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                if (model.CreatedBy == UserId)
                {
                    model.UserName = input.UserName;
                    model.RealName = input.RealName;
                    model.Mobile = input.Mobile;
                    model.QQ = input.QQ;
                    model.Email = input.Email;
                    model.Weixin = input.Weixin;
                    model.Gender = input.Gender;
                    model.Status = input.Status;
                    model.Remark = input.Remark;
                    model.ModifiedAt = DateTime.Now;
                    repo.UnitOfWork.SaveChanges();
                    SetResponse(s => s.Success, input, result);
                }
                else
                {
                    SetResponse(s => s.UpdateFailed, input, result);
                }
            }
            return JsonNet(result);
        }
        public ActionResult Delete(int userId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<User>();
            var model = repo.GetFiltered(f => f.Id == userId).FirstOrDefault();
            if (model != null)
            {
                if (model.CreatedBy == UserId)
                {
                    repo.Delete(model);
                    SetResponse(s => s.Success, result);
                }
                else
                {
                    SetResponse(s => s.DeleteFailed, result);
                }
            }
            else
            {
                SetResponse(s => s.UserNotExist, result);
            }
            return JsonNet(result);
        }
    }
}