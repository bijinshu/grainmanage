using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Web.Models;
using GrainManage.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult New(OrderDto input)
        {
            var result = new BaseOutput();
            if (input.CompId <= 0 || string.IsNullOrEmpty(input.CompName))
            {
                SetResponse(s => s.NoCompany, result);
            }
            else if (input.Details == null || !input.Details.Any() || input.Details.Any(a => a.ProductId <= 0))
            {
                SetResponse(s => s.NoProduct, result);
            }
            else if (input.Details.Any(a => a.Weight <= 0))
            {
                SetResponse(s => s.NoWeight, result);
            }
            else if (input.CompId == CookieUser.CompId)
            {
                SetResponse(s => s.NoValidOrderUser, result);
            }
            else
            {
                var repo = GetRepo<Order>();
                var detailRepo = GetRepo<OrderDetail>();
                var today = DateTime.Now.Date;
                var todayOrderProductNameList = detailRepo.GetFiltered(f => f.UserId == UserId && f.CreatedAt >= today).Select(s => s.ProductName).ToList();
                var orderedProductList = input.Details.Select(s => s.ProductName).Intersect(todayOrderProductNameList);
                if (orderedProductList.Any())
                {
                    SetResponse(s => s.OrderSended, result, $"已经请求过来收购 {string.Join(",", orderedProductList)} 了,不允许重复请求");
                }
                else
                {
                    SetEmptyIfNull(input);
                    var model = MapTo<Order>(input);
                    model.UserId = UserId;
                    model.Status = OrderStatus.WaittingForReceive;
                    var detailModelList = MapTo<List<OrderDetail>>(input.Details);
                    using (var trans = repo.UnitOfWork.BeginTransaction())
                    {
                        try
                        {
                            repo.Add(model);
                            foreach (var item in detailModelList)
                            {
                                item.OrderId = model.Id;
                                item.UserId = UserId;
                                item.TotalMoney = Math.Round(item.Price * item.Weight, 2);
                            }
                            detailRepo.Add(detailModelList);
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                        }
                    }
                    result.data = model.Id;
                    if (model.Id > 0)
                    {
                        SetResponse(s => s.Success, result);
                    }
                    else
                    {
                        SetResponse(s => s.InsertFailed, result);
                    }
                }
            }
            return JsonNet(result);
        }
    }
}