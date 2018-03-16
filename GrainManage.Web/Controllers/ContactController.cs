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
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false);
            if (list.Any())
            {
                result.total = total;
                var tradeRepo = GetRepo<Trade>();
                var contactIdList = list.Select(s => s.Id).ToList();
                var existedTradeList = tradeRepo.GetFiltered(f => f.CompId == currentUser.CompId && contactIdList.Contains(f.ContactId)).GroupBy(s => s.ContactId).Select(s => new { ContactId = s.Key, Count = s.Count() }).ToList();
                var dtoList = MapTo<List<ContactDto>>(list);
                foreach (var item in dtoList)
                {
                    if (currentUser.Roles.Contains(GlobalVar.Role_Shop) || item.CreatedBy == currentUser.UserId)
                    {
                        item.CanModify = true;
                    }
                    var trade = existedTradeList.FirstOrDefault(a => a.ContactId == item.Id);
                    if (trade != null)
                    {
                        item.TradeCount = trade.Count;
                    }
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 选择联系人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult GetList(InputSearch input)
        {
            var result = new BaseOutput();
            Expression<Func<Contact, bool>> myFilter = f => f.CompId == CookieUser.CompId;
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
            var repo = GetRepo<Contact>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false);
            if (list.Any())
            {
                result.total = total;
                result.data = list.Select(s => new { s.Id, s.ContactName, s.Mobile, s.Address });
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult New(ContactDto input)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<Contact>();
            if (string.IsNullOrEmpty(input.ContactName))
            {
                SetResponse(s => s.ContactNameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Mobile))
            {
                SetResponse(s => s.ContactMobileEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.ContactName == input.ContactName && f.Mobile == input.Mobile && f.CompId == currentUser.CompId).Any())
            {
                SetResponse(s => s.ContactExisted, input, result);
            }
            else
            {
                input.CreatedBy = currentUser.UserId;
                input.CompId = currentUser.CompId;
                SetEmptyIfNull(input);
                var model = MapTo<Contact>(input);
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
            return JsonNet(result);
        }

        public ActionResult Edit(ContactDto input)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            SetEmptyIfNull(input);
            var repo = GetRepo<Contact>();

            if (string.IsNullOrEmpty(input.ContactName))
            {
                SetResponse(s => s.ContactNameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Mobile))
            {
                SetResponse(s => s.ContactMobileEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.ContactName == input.ContactName && f.Mobile == input.Mobile && f.Id != input.Id && f.CompId == currentUser.CompId).Any())
            {
                SetResponse(s => s.ContactExisted, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                model.ContactName = input.ContactName;
                model.Address = input.Address;
                model.Mobile = input.Mobile;
                model.Weixin = input.Weixin;
                model.Email = input.Email;
                model.QQ = input.QQ;
                model.Remark = input.Remark;
                model.ModifiedAt = DateTime.Now;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
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
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.DeleteFailed, result);
            }
            return JsonNet(result);
        }
    }
}
