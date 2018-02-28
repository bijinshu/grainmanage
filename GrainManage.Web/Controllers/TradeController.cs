using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;
using DataBase.GrainManage.Models.BM;

namespace GrainManage.Web.Controllers
{
    public class TradeController : BaseController
    {
        public ActionResult Index(InputSearchDetail input)
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
            int total = 0;
            var repo = GetRepo<Trade>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.CreatedAt, false);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.total = total;
                var dtoList = MapTo<List<TradeDto>>(list);
                var contactRepo = GetRepo<Contact>();
                var userRepo = GetRepo<User>();
                var userIdList = dtoList.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]");
                foreach (var item in dtoList)
                {
                    if (item.CreatedBy == currentUser.UserId || currentUser.Roles.Contains(int.Parse(GlobalVar.Role_Shop)))
                    {
                        item.CanModify = true;
                    }
                    if (usertDic.ContainsKey(item.CreatedBy))
                    {
                        item.Creator = usertDic[item.CreatedBy];
                    }
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
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
            var repo = GetRepo<Trade>();
            var model = repo.Get(input.Id);
            model.ProductId = input.ProductId;
            model.ProductName = input.ProductName;
            model.ContactName = input.ContactName;
            model.Price = input.Price;
            model.Weight = input.Weight;
            model.TradeType = input.TradeType;
            model.Remark = input.Remark;
            model.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }

        public ActionResult GetByID(int tradeId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Trade>();
            var trade = repo.GetFiltered(f => f.Id == tradeId && f.CreatedBy == UserId).FirstOrDefault();
            if (trade == null)
            {
                SetResponse(s => s.NoData, null, result);
            }
            else
            {
                result.data = MapTo<TradeDto>(trade);
                SetResponse(s => s.Success, null, result);
            }
            return JsonNet(result);
        }

        public ActionResult Delete(int tradeId)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<Trade>();
            var model = repo.GetFiltered(f => f.Id == tradeId && f.CompId == currentUser.CompId).FirstOrDefault();
            if (model != null && (model.CreatedBy == currentUser.UserId || currentUser.Roles.Contains(int.Parse(GlobalVar.Role_Shop))))
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
