using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class PriceController : BaseController
    {
        public ActionResult SearchRecentPrice(InputSearchRecentPrice input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Price, bool>> myFilter = p => p.Creator == creator;
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (!string.IsNullOrEmpty(input.PriceType))
            {
                myFilter = myFilter.And(f => f.PriceType.Contains(input.PriceType));
            }
            var repo = GetRepo<Price>();
            var query = repo.GetFiltered(myFilter);
            var querySet = from p in query
                           join g in
                               (from p1 in query
                                group p1 by new { p1.Creator, p1.PriceType, p1.Grain } into g1
                                select new
                                {
                                    g1.Key.Creator,
                                    g1.Key.PriceType,
                                    g1.Key.Grain,
                                    MaxDate = g1.Max(item => item.Created)
                                })
                               on new { p.Creator, p.PriceType, p.Grain, p.Created } equals new { g.Creator, g.PriceType, g.Grain, Created = g.MaxDate }
                           select p;
            result.total = querySet.Count();
            querySet = querySet.OrderBy(o => o.Grain).Skip(input.PageIndex * input.PageSize).Take(input.PageSize);
            var list = querySet.ToList();
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.data = MapTo<List<PriceDto>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult SearchPrice(InputSearchPrice input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var creator = UserName;
            Expression<Func<Price, bool>> myFilter = p => p.Creator == creator;
            if (!string.IsNullOrEmpty(input.Grain))
            {
                myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
            }
            if (!string.IsNullOrEmpty(input.PriceType))
            {
                myFilter = myFilter.And(f => f.PriceType.Contains(input.PriceType));
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
            var repo = GetRepo<Price>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.Created, false);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                result.data = MapTo<List<PriceDto>>(list);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }

        public ActionResult NewPrice(InputInsert input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            input.Price.Creator = UserName;
            var model = MapTo<Price>(input.Price);
            var repo = GetRepo<Price>();
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

        public ActionResult EditPrice(InputUpdate input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var price = input.Price;
            price.Creator = UserName;
            var repo = GetRepo<Price>();
            var model = repo.GetFiltered(f => f.Id == price.PriceId, true).First();
            model.Grain = price.Grain;
            model.Creator = price.Creator;
            model.PriceType = price.PriceType;
            model.Remark = price.Remarks;
            model.UnitPrice = price.UnitPrice;
            model.Modified = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }

        [HttpPost]
        public ActionResult Delete(int priceId)
        {
            var result = new BaseOutput();
            var creator = UserName;
            var repo = GetRepo<Price>();
            var model = repo.GetFiltered(f => f.Id == priceId && f.Creator == creator).FirstOrDefault();
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
