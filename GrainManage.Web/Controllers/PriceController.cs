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
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            Expression<Func<PriceInfo, bool>> myFilter = p => p.CreatedBy == currentUser.UserId;
            if (!string.IsNullOrEmpty(input.ProductName))
            {
                myFilter = myFilter.And(f => f.ProductName.Contains(input.ProductName));
            }
            if (input.PriceType.HasValue)
            {
                myFilter = myFilter.And(f => f.PriceType == input.PriceType);
            }
            int total = 0;
            var repo = GetRepo<PriceInfo>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.CreatedAt, false);
            result.total = total;
            var dtoList = MapTo<List<PriceDto>>(list);
            if (!list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                var userRepo = GetRepo<User>();
                var userIdList = dtoList.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]");
                foreach (var item in dtoList)
                {
                    if (currentUser.UserId == item.CreatedBy || currentUser.Level >= GlobalVar.AdminLevel || currentUser.Roles.Contains(GlobalVar.Role_Shop))
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

        public ActionResult GetPriceList()
        {
            var repo = GetRepo<PriceInfo>();
            var currentUser = CurrentUser;
            var productRepo = GetRepo<Product>();
            var productIdList = productRepo.GetFiltered(f => f.Type == 1).Select(s => s.Id).ToList();
            var list = repo.GetFiltered(f => productIdList.Contains(f.ProductId) || f.CompId == currentUser.CompId).Select(s => new { s.ProductId, s.Price, s.PriceType, s.ProductName, s.CompId }).ToList();
            var repeatedList = list.GroupBy(s => new { s.ProductName, s.PriceType }).Select(s => new { s.Key.ProductName, s.Key.PriceType, Count = s.Count() }).Where(s => s.Count > 1);
            foreach (var item in repeatedList)
            {
                list.RemoveAll(s => s.ProductName == item.ProductName && s.PriceType == item.PriceType && s.CompId != currentUser.CompId);
            }
            return JsonNet(list.ToDictionary(k => $"{k.ProductId}-{k.PriceType}", v => v.Price));
        }

        public ActionResult New(PriceDto input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<PriceInfo>();
            if (input.ProductId <= 0)
            {
                SetResponse(s => s.ProductNotSelected, input, result);
            }
            else if (repo.GetFiltered(f => f.CompId == currentUser.CompId && f.ProductId == input.ProductId && f.PriceType == input.PriceType).Any())
            {
                SetResponse(s => s.PriceExisted, input, result);
            }
            else
            {
                SetEmptyIfNull(input);
                var productRepo = GetRepo<Product>();
                var product = productRepo.GetFiltered(f => f.Id == input.ProductId).First();
                var model = MapTo<PriceInfo>(input);
                model.Id = 0;
                model.ProductName = product.Name;
                model.CompId = currentUser.CompId;
                model.CreatedBy = currentUser.UserId;
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

        public ActionResult Edit(PriceDto input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<PriceInfo>();
            var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
            model.PriceType = input.PriceType;
            model.Remark = input.Remark ?? string.Empty;
            model.Price = input.Price;
            model.ModifiedAt = DateTime.Now;
            model.ModifiedBy = currentUser.UserId;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
            return JsonNet(result);
        }

        [HttpPost]
        public ActionResult Delete(int priceId)
        {
            var result = new BaseOutput();
            var currentUser = CurrentUser;
            var repo = GetRepo<PriceInfo>();
            var model = repo.GetFiltered(f => f.Id == priceId && f.CompId == currentUser.CompId).FirstOrDefault();
            if (model != null)
            {
                if (model.CreatedBy == currentUser.UserId || (model.CompId == currentUser.CompId && currentUser.Roles.Contains(GlobalVar.Role_Shop)))
                {
                    repo.Delete(model);
                    SetResponse(s => s.Success, result);
                }
                else
                {
                    SetResponse(s => s.DeleteFailed, result);
                }
            }
            else
            {
                SetResponse(s => s.DeleteFailed, result);
            }
            return JsonNet(result);
        }
    }
}
