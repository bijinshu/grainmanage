using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class TradeController : BaseController
    {
        public ActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            Expression<Func<Trade, bool>> myFilter = f => f.CompId == currentUser.CompId;
            if (input.TradeType.HasValue)
            {
                myFilter = myFilter.And(f => f.TradeType == input.TradeType);
            }
            if (!string.IsNullOrEmpty(input.ProductName))
            {
                myFilter = myFilter.And(f => f.ProductName.Contains(input.ProductName));
            }
            if (!string.IsNullOrEmpty(input.ContactName))
            {
                myFilter = myFilter.And(f => f.ContactName.Contains(input.ContactName));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
            }
            var repo = GetRepo<Trade>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false);
            if (list.Any())
            {
                result.total = total;
                var dtoList = MapTo<List<TradeDto>>(list);
                var contactRepo = GetRepo<Contact>();
                var userRepo = GetRepo<User>();
                var userIdList = dtoList.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]".Replace("[]", string.Empty));
                var compRepo = GetRepo<Company>();
                var compIdList = list.Select(s => s.CompId).Distinct().ToList();
                var compList = compRepo.GetFiltered(f => compIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                foreach (var item in dtoList)
                {
                    if (item.CreatedBy == currentUser.UserId || currentUser.Roles.Contains(GlobalVar.Role_Shop))
                    {
                        item.CanModify = true;
                    }
                    if (usertDic.ContainsKey(item.CreatedBy))
                    {
                        item.Creator = usertDic[item.CreatedBy];
                    }
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

        public ActionResult New(TradeDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var currentUser = CurrentUser;
            input.CreatedBy = currentUser.UserId;
            input.CompId = currentUser.CompId;
            if (!string.IsNullOrEmpty(input.ContactName))
            {
                input.ContactName = input.ContactName.Trim();
                var contactRepo = GetRepo<Contact>();
                var contactList = contactRepo.GetFiltered(f => f.CompId == currentUser.CompId && f.ContactName == input.ContactName).ToList();
                if (contactList.Any())
                {
                    if (contactList.Count == 1)
                    {
                        input.ContactId = contactList.First().Id;
                    }
                    else if (input.ContactId > 0 && !contactList.Any(a => a.Id == input.ContactId))
                    {
                        input.ContactId = 0;
                    }
                }
                else
                {
                    input.ContactId = 0;
                }
            }
            else
            {
                input.ContactId = 0;
            }
            var repo = GetRepo<Trade>();
            var model = repo.Add(MapTo<Trade>(input));
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

        public ActionResult Edit(TradeDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            if (!string.IsNullOrEmpty(input.ContactName))
            {
                var currentUser = CurrentUser;
                input.ContactName = input.ContactName.Trim();
                var contactRepo = GetRepo<Contact>();
                var contactList = contactRepo.GetFiltered(f => f.CompId == currentUser.CompId && f.ContactName == input.ContactName).ToList();
                if (contactList.Any())
                {
                    if (contactList.Count == 1)
                    {
                        input.ContactId = contactList.First().Id;
                    }
                    else if (input.ContactId > 0 && !contactList.Any(a => a.Id == input.ContactId))
                    {
                        input.ContactId = 0;
                    }
                }
                else
                {
                    input.ContactId = 0;
                }
            }
            else
            {
                input.ContactId = 0;
            }
            var repo = GetRepo<Trade>();
            var model = repo.Get(input.Id);
            model.ProductId = input.ProductId;
            model.ProductName = input.ProductName;
            model.ContactId = input.ContactId;
            model.ContactName = input.ContactName;
            model.Price = input.Price;
            model.Weight = input.Weight;
            model.ActualMoney = input.ActualMoney;
            model.TradeType = input.TradeType;
            model.Remark = input.Remark;
            model.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }

        public ActionResult GetByContactId(int contactId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Trade>();
            var list = repo.GetFiltered(f => f.ContactId == contactId).ToList();
            if (!list.Any())
            {
                SetResponse(s => s.NoData, null, result);
            }
            else
            {
                var dtoList = MapTo<List<TradeDto>>(list);
                var userRepo = GetRepo<User>();
                var userIdList = dtoList.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]".Replace("[]", string.Empty));
                foreach (var item in dtoList)
                {
                    if (usertDic.ContainsKey(item.CreatedBy))
                    {
                        item.Creator = usertDic[item.CreatedBy];
                    }
                }
                result.data = dtoList;
                SetResponse(s => s.Success, null, result);
            }
            return JsonNet(result, true);
        }

        public ActionResult Delete(int tradeId)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<Trade>();
            var model = repo.GetFiltered(f => f.Id == tradeId && f.CompId == currentUser.CompId).FirstOrDefault();
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
