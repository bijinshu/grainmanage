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
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            Expression<Func<Contact, bool>> myFilter = f => f.CreatedBy == UserId;
            if (!string.IsNullOrEmpty(input.Name))
            {
                myFilter = myFilter.And(f => f.ContactName.Contains(input.Name));
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
                result.data = MapTo<List<ContactDto>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult New(ContactDto input)
        {
            var result = new BaseOutput();
            input.CreatedBy = UserId;
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
            input.CreatedBy = UserId;
            var repo = GetRepo<Contact>();
            if (!repo.GetFiltered(f => f.ContactName == input.ContactName && f.Mobile == input.Mobile && f.Id != input.Id && f.CreatedBy == input.CreatedBy).Any())
            {
                var model = repo.GetFiltered(f => f.Id == input.Id && f.CreatedBy == input.CreatedBy, true).First();
                model.ContactName = input.ContactName;
                model.Address = input.Address;
                model.BirthDate = input.BirthDate;
                model.Mobile = input.Mobile;
                model.CreatedBy = input.CreatedBy;
                model.Email = input.Email;
                model.Gender = input.Gender;
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
            var model = repo.GetFiltered(f => f.Id == contactId && f.CreatedBy == UserId).FirstOrDefault();
            if (model != null)
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
