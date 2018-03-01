using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Contact;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            Expression<Func<Contact, bool>> myFilter = f => f.CompId == currentUser.CompId;
            if (!string.IsNullOrEmpty(input.Name))
            {
                myFilter = myFilter.And(f => f.ContactName.Contains(input.Name));
            }
            if (!string.IsNullOrEmpty(input.Mobile))
            {
                myFilter = myFilter.And(f => f.Mobile.Contains(input.Mobile));
            }
            if (!string.IsNullOrEmpty(input.Address))
            {
                myFilter = myFilter.And(f => f.Address.Contains(input.Address));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
            }
            int total = 0;
            var repo = GetRepo<Contact>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.CreatedAt, false);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.total = total;
                var dtoList = MapTo<List<ContactDto>>(list);
                foreach (var item in dtoList)
                {
                    if (currentUser.Roles.Contains(GlobalVar.Role_Shop) || item.CreatedBy == currentUser.UserId)
                    {
                        item.CanModify = true;
                    }
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult New(ContactDto input)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            input.CreatedBy = currentUser.UserId;
            input.CompId = currentUser.CompId;
            SetEmptyIfNull(input);
            var model = MapTo<Contact>(input);
            var repo = GetRepo<Contact>();
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
            return JsonNet(result);
        }

        public ActionResult Edit(ContactDto input)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            SetEmptyIfNull(input);
            var repo = GetRepo<Contact>();
            if (!repo.GetFiltered(f => f.ContactName == input.ContactName && f.Mobile == input.Mobile && f.Id != input.Id && f.CompId == currentUser.CompId).Any())
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                model.ContactName = input.ContactName;
                model.Address = input.Address;
                model.Mobile = input.Mobile;
                model.Email = input.Email;
                model.ModifiedAt = DateTime.Now;
                model.QQ = input.QQ;
                model.Remark = input.Remark;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.ContactExisted, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult Delete(int contactId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Contact>();
            var currentUser = CurrentUser;
            var model = repo.GetFiltered(f => f.Id == contactId && f.CompId == currentUser.CompId).FirstOrDefault();
            if (model != null && (model.CreatedBy == currentUser.UserId || currentUser.Roles.Contains(GlobalVar.Role_Shop)))
            {
                repo.Delete(model);
                SetResponse(s => s.Success, null, result);
            }
            else
            {
                SetResponse(s => s.DeleteFailed, null, result);
            }
            return JsonNet(result);
        }
    }
}
