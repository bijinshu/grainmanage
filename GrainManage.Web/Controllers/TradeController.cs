using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;
using DataBase.GrainManage.Models.Log;
using System.Text;
using GrainManage.Web.Common;
using GrainManage.Web.Services;

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
                var detailRepo = GetRepo<TradeDetail>();
                var query = detailRepo.GetFiltered(f => f.ProductName.Contains(input.ProductName)).Select(s => s.TradeId);
                myFilter = myFilter.And(f => query.Contains(f.Id));
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
                var contactRepo = GetRepo<Contact>();
                var userRepo = GetRepo<User>();
                var userIdList = list.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]".Replace("[]", string.Empty));
                var compRepo = GetRepo<Company>();
                var compIdList = list.Select(s => s.CompId).Distinct().ToList();
                var compList = compRepo.GetFiltered(f => compIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                var detailRepo = GetRepo<TradeDetail>();
                var idList = list.Select(s => s.Id).ToList();
                var detailList = detailRepo.GetFiltered(f => idList.Contains(f.TradeId)).ToList();
                var dtoList = MapTo<List<TradeDto>>(list);
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
                    item.Details = MapTo<List<TradeDetailDto>>(detailList.Where(f => f.TradeId == item.Id).ToList());
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
            var detailRepo = GetRepo<TradeDetail>();
            var model = MapTo<Trade>(input);
            var detailModelList = MapTo<List<TradeDetail>>(input.Details);
            using (var trans = repo.UnitOfWork.BeginTransaction())
            {
                try
                {
                    repo.Add(model);
                    foreach (var item in detailModelList)
                    {
                        item.TradeId = model.Id;
                        item.CreatedBy = currentUser.UserId;
                        item.Remark = item.Remark ?? string.Empty;
                        item.CreatedAt = DateTime.Now;
                    }
                    detailRepo.Add(detailModelList);
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    var exception = new ExceptionLog
                    {
                        Path = HttpUtility.UrlDecode(Request.Path.Value, Encoding.UTF8),
                        Para = HttpUtil.GetInputPara(Request),
                        Message = ExceptionUtil.GetInnerestMessage(e),
                        StackTrace = e.StackTrace,
                        ClientIP = HttpUtil.GetRequestHostAddress(Request),
                        CreatedAt = DateTime.Now
                    };
                    LogService.AddExceptionLog(exception);
                }
            }
            result.data = model.Id;
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }

        public ActionResult Edit(TradeDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var currentUser = CurrentUser;
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
            var detailRepo = GetRepo<TradeDetail>();
            var detailModelList = detailRepo.GetFiltered(f => f.TradeId == input.Id, true).ToList();
            var validDetailList = new List<TradeDetail>();
            repo.UnitOfWork.LazyCommitEnabled = true;
            foreach (var detail in input.Details)
            {
                if (detail.Id > 0)
                {
                    var detailModel = detailModelList.FirstOrDefault(f => f.Id == detail.Id);
                    if (detailModel != null)
                    {
                        detailModel.ProductId = detail.ProductId;
                        detailModel.ProductName = detail.ProductName;
                        detailModel.RoughWeight = detail.RoughWeight;
                        detailModel.Tare = detail.Tare;
                        detailModel.Price = detail.Price;
                        detailModel.ActualMoney = detail.ActualMoney;
                        detailModel.Remark = detail.Remark ?? string.Empty;
                        detailModel.ModifiedAt = DateTime.Now;
                    }
                }
                else
                {
                    var detailModel = MapTo<TradeDetail>(detail);
                    SetEmptyIfNull(detailModel);
                    detailModel.TradeId = input.Id;
                    detailModel.CreatedAt = DateTime.Now;
                    detailModel.CreatedBy = currentUser.UserId;
                    detailRepo.Add(detailModel);
                }
            }
            var deletedDetailModelList = detailModelList.Where(f => !input.Details.Any(a => a.Id == f.Id)).ToList();
            detailRepo.Delete(deletedDetailModelList);
            var model = repo.Get(input.Id);
            model.ContactId = input.ContactId;
            model.ContactName = input.ContactName;
            model.ActualMoney = input.ActualMoney;
            model.TradeType = input.TradeType;
            model.Remark = input.Remark;
            model.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges(true);
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
