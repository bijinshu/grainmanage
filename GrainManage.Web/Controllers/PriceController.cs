using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class PriceController : BaseController
    {
        //public ActionResult SearchPrice(InputSearchPrice input)
        //{
        //    if (IsGetRequest)
        //    {
        //        return View();
        //    }
        //    var result = new BaseOutput();
        //    var creator = UserId;
        //    Expression<Func<PriceInfo, bool>> myFilter = p => p.CreatedBy == creator;
        //    if (!string.IsNullOrEmpty(input.Grain))
        //    {
        //        myFilter = myFilter.And(f => f.Grain.Contains(input.Grain));
        //    }
        //    if (!string.IsNullOrEmpty(input.PriceType))
        //    {
        //        myFilter = myFilter.And(f => f.PriceType.Contains(input.PriceType));
        //    }
        //    if (input.StartTime.HasValue)
        //    {
        //        myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
        //    }
        //    if (input.EndTime.HasValue)
        //    {
        //        myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
        //    }
        //    int total = 0;
        //    var repo = GetRepo<PriceInfo>();
        //    var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.CreatedAt, false);
        //    if (!list.Any())
        //    {
        //        SetResponse(s => s.NoData, input, result);
        //    }
        //    else
        //    {
        //        result.data = MapTo<List<PriceDto>>(list);
        //        SetResponse(s => s.Success, input, result);
        //    }
        //    return JsonNet(result);
        //}

        public ActionResult GetPriceList()
        {
            var repo = GetRepo<PriceInfo>();
            var currentUser = CurrentUser;
            var list = repo.GetFiltered(f => f.CompId == currentUser.CompId).Select(s => new { s.ProductId, s.Price, s.PriceType }).ToList();
            return JsonNet(list.ToDictionary(k => $"{k.ProductId}-{k.PriceType}", v => v.Price));
        }

        //public ActionResult New(InputInsert input)
        //{
        //    if (IsGetRequest)
        //    {
        //        return View();
        //    }
        //    var result = new BaseOutput();
        //    input.Price.CreatedBy = UserId;
        //    var model = MapTo<PriceInfo>(input.Price);
        //    var repo = GetRepo<PriceInfo>();
        //    model = repo.Add(model);
        //    result.data = model.Id;
        //    if (model.Id > 0)
        //    {
        //        SetResponse(s => s.Success, input, result);
        //    }
        //    else
        //    {
        //        SetResponse(s => s.InsertFailed, input, result);
        //    }
        //    return JsonNet(result);
        //}

        //public ActionResult Edit(InputUpdate input)
        //{
        //    if (IsGetRequest)
        //    {
        //        return View();
        //    }
        //    var result = new BaseOutput();
        //    var price = input.Price;
        //    price.CreatedBy = UserId;
        //    var repo = GetRepo<PriceInfo>();
        //    var model = repo.GetFiltered(f => f.Id == price.PriceId, true).First();
        //    model.Grain = price.Grain;
        //    model.CreatedBy = price.CreatedBy;
        //    model.PriceType = price.PriceType;
        //    model.Remark = price.Remarks;
        //    model.UnitPrice = price.UnitPrice;
        //    model.ModifiedAt = DateTime.Now;
        //    repo.UnitOfWork.SaveChanges();
        //    SetResponse(s => s.Success, input, result);
        //    return JsonNet(result);
        //}

        [HttpPost]
        public ActionResult Delete(int priceId)
        {
            var result = new BaseOutput();
            var creator = UserId;
            var repo = GetRepo<PriceInfo>();
            var model = repo.GetFiltered(f => f.Id == priceId && f.CreatedBy == creator).FirstOrDefault();
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
