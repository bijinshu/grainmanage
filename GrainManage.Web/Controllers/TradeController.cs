using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class TradeController : BaseController
    {
        public ActionResult SearchTrade()
        {
            return View();
        }

        public ActionResult NewTrade(InputInsert input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            input.Trade.Creator = UserName;
            var repo = GetRepo<Trade>();
            var model = repo.Add(MapTo<Trade>(input.Trade));
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

        public ActionResult EditTrade(InputUpdate input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            input.Trade.Creator = UserName;
            var now = DateTime.Now;
            var model = MapTo<Trade>(input.Trade);
            model.Modified = now;
            var repo = GetRepo<Trade>();
            repo.Update(model);
            model = repo.GetFiltered(f => f.Id == input.Trade.TradeId).First();
            if (model.Modified == now)
            {
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.UpdateFailed, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult GetByID(int tradeId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Trade>();
            var trade = repo.GetFiltered(f => f.Id == tradeId && f.Creator == UserName).FirstOrDefault();
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

        [HttpPost]
        public ActionResult SearchDetail(InputSearchDetail input)
        {
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Trade, bool>> myFilter = f => f.Creator == creator;
            if (!string.IsNullOrEmpty(input.TradeType))
            {
                myFilter = myFilter.And(f => f.TradeType.Contains(input.TradeType));
            }
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (!string.IsNullOrEmpty(input.ContactName))
            {
                myFilter = myFilter.And(f => f.Contact.ContactName.Contains(input.ContactName));
            }
            if (!string.IsNullOrEmpty(input.Area))
            {
                myFilter = myFilter.And(f => f.Contact.Area.Contains(input.Area));
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
            var repo = GetRepo<Trade>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.Created, false);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.total = total;
                result.data = MapTo<List<TradeDetailView>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        [HttpPost]
        public ActionResult GetTotal(InputGetTotal input)
        {
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Trade, bool>> myFilter = f => f.Creator == creator;
            if (!string.IsNullOrEmpty(input.TradeType))
            {
                myFilter = myFilter.And(f => f.TradeType.Contains(input.TradeType));
            }
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created <= input.EndTime);
            }
            var repo = GetRepo<Trade>();
            var query = repo.GetFiltered(myFilter).GroupBy(g => new { g.Creator, g.Grain, g.TradeType }).Select(g => new
            {
                g.Key.Creator,
                g.Key.Grain,
                g.Key.TradeType,
                Frequency = g.Count(),
                TotalAmount = g.Sum(item => item.Weight),
                TotalMoney = g.Sum(item => item.Weight * item.Price),
                ActualTotalMoney = g.Sum(item => item.ActualMoney),
            });
            result.total = query.Count();
            query = query.OrderBy(o => o.TradeType).ThenByDescending(o => o.ActualTotalMoney).Skip(input.PageIndex * input.PageSize).Take(input.PageSize);
            var list = query.ToList();
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.data = DynamicMap<List<TradeTotalView>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        [HttpPost]
        public ActionResult GetTotalByArea(InputGetTotalByArea input)
        {
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Trade, bool>> myFilter = f => f.Creator == creator;
            if (!string.IsNullOrEmpty(input.TradeType))
            {
                myFilter = myFilter.And(f => f.TradeType.Contains(input.TradeType));
            }
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (!string.IsNullOrEmpty(input.Area))
            {
                myFilter = myFilter.And(f => f.Contact.Area.Contains(input.Area));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created <= input.EndTime);
            }
            var repo = GetRepo<Trade>();
            var query = repo.GetFiltered(myFilter).GroupBy(g => new { g.Creator, g.Contact.Area, g.Grain, g.TradeType }).Select(g => new
            {
                g.Key.Creator,
                g.Key.Area,
                g.Key.Grain,
                g.Key.TradeType,
                Frequency = g.Count(),
                TotalAmount = g.Sum(item => item.Weight),
                TotalMoney = g.Sum(item => item.Weight * item.Price),
                ActualTotalMoney = g.Sum(item => item.ActualMoney),
            });
            result.total = query.Count();
            query = query.OrderBy(o => o.TradeType).ThenByDescending(o => o.ActualTotalMoney).Skip(input.PageIndex * input.PageSize).Take(input.PageSize);
            var list = query.ToList();
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.data = DynamicMap<List<TradeTotalWithAreaView>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        [HttpPost]
        public ActionResult GetTotalByContactArea(InputGetTotalByContact input)
        {
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Trade, bool>> myFilter = f => f.Creator == creator;
            if (!string.IsNullOrEmpty(input.TradeType))
            {
                myFilter = myFilter.And(f => f.TradeType.Contains(input.TradeType));
            }
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (!string.IsNullOrEmpty(input.ContactName))
            {
                myFilter = myFilter.And(f => f.Contact.ContactName.Contains(input.ContactName));
            }
            if (!string.IsNullOrEmpty(input.Area))
            {
                myFilter = myFilter.And(f => f.Contact.Area.Contains(input.Area));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.Created <= input.EndTime);
            }
            var repo = GetRepo<Trade>();
            var query = repo.GetFiltered(myFilter).GroupBy(g => new { g.Creator, ContactID = g.ContactId, g.Contact.Area, g.Grain, g.TradeType }).Select(g => new
            {
                g.Key.Creator,
                ContactName = g.First(item => item.ContactId == g.Key.ContactID).Contact.ContactName,
                g.Key.Area,
                g.Key.Grain,
                TradeType = g.Key.TradeType,
                Frequency = g.Count(),
                TotalAmount = g.Sum(item => item.Weight),
                TotalMoney = g.Sum(item => item.Weight * item.Price),
                ActualTotalMoney = g.Sum(item => item.ActualMoney),
            });
            result.total = query.Count();
            query = query.OrderBy(o => o.TradeType).ThenByDescending(o => o.ActualTotalMoney).Skip(input.PageIndex * input.PageSize).Take(input.PageSize);
            var list = query.ToList();
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.data = DynamicMap<List<TradeWithContactView>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult Delete(int tradeId)
        {
            var result = new BaseOutput();
            var creator = UserName;
            var repo = GetRepo<Trade>();
            var model = repo.GetFiltered(f => f.Id == tradeId && f.Creator == creator).FirstOrDefault();
            if (model != null)
            {
                repo.Delete(model);
                model = repo.GetFiltered(f => f.Id == tradeId && f.Creator == creator).FirstOrDefault();
            }
            if (model == null)
            {
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
