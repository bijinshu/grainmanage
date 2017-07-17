using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Contact;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Contact, bool>> myFilter = f => f.Creator == creator;
            if (input.IsOr)
            {
                Expression<Func<Contact, bool>> subFilter = null;
                if (!string.IsNullOrEmpty(input.Name))
                {
                    subFilter = (Contact f) => f.ContactName.Contains(input.Name);
                }
                if (!string.IsNullOrEmpty(input.Area))
                {
                    subFilter = subFilter == null ? (Contact f) => f.Area.Contains(input.Area) : subFilter.Or(f => f.Area.Contains(input.Area));
                }
                if (!string.IsNullOrEmpty(input.Address))
                {
                    subFilter = subFilter == null ? (Contact f) => f.Address.Contains(input.Address) : subFilter.Or(f => f.Address.Contains(input.Address));
                }
                if (subFilter != null)
                {
                    myFilter = myFilter.And(subFilter);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(input.Name))
                {
                    myFilter = myFilter.And(f => f.ContactName.Contains(input.Name));
                }
                if (!string.IsNullOrEmpty(input.Area))
                {
                    myFilter = myFilter.And(f => f.Area.Contains(input.Area));
                }
                if (!string.IsNullOrEmpty(input.Address))
                {
                    myFilter = myFilter.And(f => f.Address.Contains(input.Address));
                }
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created <= input.EndTime);
            }
            int total = 0;
            var repo = GetRepo<Contact>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.Created, false);
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

        public ActionResult NewContact(ContactDto input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            input.Creator = UserName;
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

        public ActionResult EditContact(ContactDto input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var contact = input;
            contact.Creator = UserName;
            var repo = GetRepo<Contact>();
            var model = repo.GetFiltered(f => f.Id == contact.Id && f.Creator == contact.Creator, true).First();
            model.Address = contact.Address;
            model.Area = contact.Area;
            model.BirthDate = contact.BirthDate;
            model.CellPhone = contact.CellPhone;
            model.ContactName = contact.ContactName;
            model.Creator = contact.Creator;
            model.Email = contact.Email;
            model.Gender = contact.Gender;
            model.Modified = DateTime.Now;
            model.QQ = contact.QQ;
            model.Remark = contact.Remark;
            model.Telephone = contact.Telephone;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
            return JsonNet(model);
        }

        [HttpPost]
        public ActionResult Delete(int contactId)
        {
            var result = new BaseOutput();
            var creator = UserName;
            var repo = GetRepo<Contact>();
            var model = repo.GetFiltered(f => f.Id == contactId && f.Creator == creator).FirstOrDefault();
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
