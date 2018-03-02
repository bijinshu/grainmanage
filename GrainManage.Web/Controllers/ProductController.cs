using DataBase.GrainManage.Models;
using GrainManage.Core;
using GrainManage.Web.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GrainManage.Web.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            var productRepo = GetRepo<Product>();
            Expression<Func<Product, bool>> myFilter = ExpressionBuilder.Where<Product>(f => true);
            if (input.ProductType.HasValue)
            {
                myFilter = myFilter.And(f => f.Type == input.ProductType);
            }
            if (currentUser.Level < GlobalVar.AdminLevel)
            {
                if (input.ProductType.HasValue)
                {
                    myFilter = myFilter.And(f => f.CompId == currentUser.CompId);
                }
                else
                {
                    myFilter = myFilter.And(f => f.CompId == currentUser.CompId || f.Type == 1);
                }
            }
            if (!string.IsNullOrEmpty(input.ProductName))
            {
                myFilter = myFilter.And(f => f.Name.Contains(input.ProductName));
            }
            if (input.Status.HasValue)
            {
                myFilter = myFilter.And(f => f.Status == input.Status);
            }
            int total = 0;
            var now = DateTime.Now;
            var list = productRepo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter).ToList();
            result.total = total;
            var dtoList = MapTo<List<ProductDto>>(list);
            if (dtoList.Any())
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
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result, true);
        }
        public ActionResult New(ProductDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            if (string.IsNullOrEmpty(input.Name))
            {
                SetResponse(s => s.ProductNameEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.Name == input.Name && (f.CompId == currentUser.CompId || f.Type == 1)).Any())
            {
                SetResponse(s => s.ProductNameExisted, input, result);
            }
            else
            {
                var now = DateTime.Now;
                var model = MapTo<Product>(input);
                model.CompId = currentUser.CompId;
                model.CreatedBy = currentUser.UserId;
                if (Level >= GlobalVar.AdminLevel)
                {
                    model.Type = input.Type;
                }
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
        public ActionResult Edit(ProductDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            if (repo.GetFiltered(f => f.Name == input.Name && (f.CompId == currentUser.CompId || f.Type == 1) && f.Id != input.Id).Any())
            {
                SetResponse(s => s.ProductNameExisted, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                if (Level >= GlobalVar.AdminLevel)
                {
                    model.Type = input.Type;
                }
                model.Name = input.Name;
                model.Status = input.Status;
                model.Remark = input.Remark;
                model.ModifiedAt = DateTime.Now;
                model.ModifiedBy = currentUser.UserId;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult Delete(int productId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            var model = repo.GetFiltered(f => f.Id == productId).FirstOrDefault();
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
                SetResponse(s => s.ProductNotExisted, result);
            }
            return JsonNet(result);
        }
        public IActionResult List()
        {
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            var list = repo.GetFiltered(f => f.Status == Status.Enabled && (f.Type == 1 || f.CompId == currentUser.CompId)).Select(s => new { s.Id, s.Name, s.Price, s.CompId }).ToList();
            var repeatedList = list.GroupBy(s => s.Name).Select(s => new { ProductName = s.Key, Count = s.Count() }).Where(s => s.Count > 1);
            foreach (var item in repeatedList)
            {
                list.RemoveAll(s => s.Name == item.ProductName && s.CompId != currentUser.CompId);
            }
            return JsonNet(list);
        }
    }
}