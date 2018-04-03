using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Core;
using GrainManage.Web.Models.Weixin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class WeixinController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            var myFilter = ExpressionBuilder.Where<Company>(f => true);
            if (!string.IsNullOrEmpty(input.Name))
            {
                myFilter = myFilter.And(f => f.Name.Contains(input.Name));
            }
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter);
            result.total = total;
            if (list.Any())
            {
                var compIdList = list.Select(s => s.Id).ToList();
                var productRepo = GetRepo<Product>();
                var productList = productRepo.GetFiltered(f => compIdList.Contains(f.CompId) && f.Status == Status.Enabled).Select(s => new { s.Id, s.Name, s.Price, s.CompId }).ToList();
                var list2 = new List<dynamic>();
                foreach (var item in list)
                {
                    var products = productList.Where(f => f.CompId == item.Id);
                    if (products.Any())
                    {
                        list2.Add(new { item.Id, CompanyName = item.Name, item.ImgName, item.Address, Products = products });
                    }
                }
                result.data = list2;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
    }
}