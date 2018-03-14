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
            if (input.Source.HasValue)
            {
                myFilter = myFilter.And(f => f.Source == input.Source);
            }
            if (currentUser.Level < GlobalVar.AdminLevel)
            {
                if (input.Source.HasValue)
                {
                    myFilter = myFilter.And(f => f.CompId == currentUser.CompId);
                }
                else
                {
                    myFilter = myFilter.And(f => f.CompId == currentUser.CompId || f.Source > 0);
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
            var list = productRepo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false).ToList();
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
            input.Id = 0;
            SetEmptyIfNull(input);
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            if (currentUser.Level < GlobalVar.AdminLevel)
            {
                input.Source = 0;
            }
            if (string.IsNullOrEmpty(input.Name))
            {
                SetResponse(s => s.ProductNameEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.Name == input.Name && f.CompId == currentUser.CompId && f.Source == input.Source).Any())
            {
                SetResponse(s => s.ProductNameExisted, input, result);
            }
            else
            {
                var now = DateTime.Now;
                var model = MapTo<Product>(input);
                model.CompId = currentUser.CompId;
                model.CreatedBy = currentUser.UserId;
                model.Source = input.Source;
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
            if (currentUser.Level < GlobalVar.AdminLevel)
            {
                input.Source = 0;
            }
            if (repo.GetFiltered(f => f.Name == input.Name && f.CompId == currentUser.CompId && f.Source == input.Source && f.Id != input.Id).Any())
            {
                SetResponse(s => s.ProductNameExisted, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
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
        public ActionResult Copy(ProductDto input)
        {
            var result = new BaseOutput();
            input.Id = 0;
            input.Source = 0;
            SetEmptyIfNull(input);
            var repo = GetRepo<Product>();
            var currentUser = CurrentUser;
            var existedModel = repo.GetFiltered(f => f.Name == input.Name && f.CompId == currentUser.CompId && f.Source == input.Source, true).FirstOrDefault();
            if (existedModel == null)
            {
                var model = MapTo<Product>(input);
                model.CompId = currentUser.CompId;
                model.CreatedBy = currentUser.UserId;
                model.Source = input.Source;
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
            else
            {
                existedModel.Price = input.Price;
                existedModel.ModifiedAt = DateTime.Now;
                existedModel.ModifiedBy = currentUser.UserId;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public IActionResult List(int? compId)
        {
            var repo = GetRepo<Product>();
            var companyId = compId.HasValue ? compId.Value : CookieUser.CompId;
            var list = repo.GetFiltered(f => f.Status == Status.Enabled && f.Source == 0 && f.CompId == companyId).Select(s => new { s.Id, s.Name, s.Price }).ToList();
            return JsonNet(list);
        }
    }
}