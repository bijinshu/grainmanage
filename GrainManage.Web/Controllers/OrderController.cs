using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Core;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using GrainManage.Web.Models.Order;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            var repo = GetRepo<Order>();
            Expression<Func<Order, bool>> myFilter = ExpressionBuilder.Where<Order>(f => true);
            if (!string.IsNullOrEmpty(input.Mobile))
            {
                myFilter = myFilter.And(f => f.Mobile.Contains(input.Mobile));
            }
            if (!string.IsNullOrEmpty(input.Address))
            {
                myFilter = myFilter.And(f => f.Address.Contains(input.Address));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
            }
            if (currentUser.Level < GlobalVar.AdminLevel)
            {
                myFilter = myFilter.And(f => f.CompId == currentUser.CompId);
            }
            if (input.Status.HasValue)
            {
                myFilter = myFilter.And(f => f.Status == input.Status);
            }
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false).ToList();
            if (list.Any())
            {
                result.total = total;
                var dtoList = MapTo<List<OrderDto>>(list);
                var userRepo = GetRepo<User>();
                var userIdList = dtoList.Select(s => s.CreatedBy).Distinct().ToList();
                var usertDic = userRepo.GetFiltered(f => userIdList.Contains(f.Id)).Select(s => new { s.Id, s.RealName, s.UserName }).ToList().ToDictionary(k => k.Id, v => $"{v.UserName}[{v.RealName}]".Replace("[]", string.Empty));
                var detailRepo = GetRepo<OrderDetail>();
                var idList = list.Select(s => s.Id).ToList();
                var detailList = detailRepo.GetFiltered(f => idList.Contains(f.OrderId)).ToList();
                foreach (var item in dtoList)
                {
                    item.CanModify = item.CompId == CookieUser.CompId;
                    if (usertDic.ContainsKey(item.CreatedBy))
                    {
                        item.Creator = usertDic[item.CreatedBy];
                    }
                    item.Details = MapTo<List<OrderDetailDto>>(detailList.Where(f => f.OrderId == item.Id));
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
        /// <summary>
        /// 创建新订单（当天每种产品只能提交给一次）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult New(OrderDto input)
        {
            var result = new BaseOutput();
            if (input.CompId <= 0 || string.IsNullOrEmpty(input.CompName))
            {
                SetResponse(s => s.NoCompany, result);
            }
            else if (string.IsNullOrEmpty(input.Mobile) || !Regex.IsMatch(input.Mobile, @"^1[34578]\d{9}$"))
            {
                SetResponse(s => s.MobileNotValid, result);
            }
            else if (input.Details == null || !input.Details.Any() || input.Details.Any(a => a.ProductId <= 0))
            {
                SetResponse(s => s.NoProduct, result);
            }
            else if (input.Details.Any(a => a.PreWeight <= 0))
            {
                SetResponse(s => s.NoWeight, result);
            }
            else if (input.CompId == CookieUser.CompId)
            {
                SetResponse(s => s.NoOrderCompSelf, result);
            }
            else
            {
                var repo = GetRepo<Order>();
                var detailRepo = GetRepo<OrderDetail>();
                var today = DateTime.Now.Date;
                var todayOrderProductNameList = detailRepo.GetFiltered(f => f.CreatedBy == UserId && f.CreatedAt >= today).Select(s => s.ProductName).ToList();
                var orderedProductList = input.Details.Select(s => s.ProductName).Intersect(todayOrderProductNameList);
                if (orderedProductList.Any())
                {
                    SetResponse(s => s.OrderSended, result, $"已经请求过收购【{string.Join(",", orderedProductList)}】了,可登陆系统查看订单状态");
                }
                else
                {
                    SetEmptyIfNull(input);
                    var model = MapTo<Order>(input);
                    model.CreatedBy = UserId;
                    model.Status = OrderStatus.WaittingForReceive;
                    var newList = new List<OrderDetailDto>();
                    foreach (var item in input.Details)//合并重复项
                    {
                        var firstItem = newList.FirstOrDefault(a => a.ProductId == item.ProductId);
                        if (firstItem == null)
                        {
                            newList.Add(item);
                        }
                        else
                        {
                            firstItem.PreWeight += item.PreWeight;
                            firstItem.PreMoney += item.PreMoney;
                        }
                    }
                    var detailModelList = MapTo<List<OrderDetail>>(newList);
                    using (var trans = repo.UnitOfWork.BeginTransaction())
                    {
                        try
                        {
                            repo.Add(model);
                            foreach (var item in detailModelList)
                            {
                                item.OrderId = model.Id;
                                item.CreatedBy = UserId;
                                item.PreMoney = Math.Round(item.Price * item.PreWeight, 2);
                            }
                            model.TotalMoney = Math.Round(detailModelList.Sum(s => s.PreMoney), 2);
                            detailRepo.Add(detailModelList);
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            model.Id = 0;
                            trans.Rollback();
                            var exception = new ExceptionLog
                            {
                                Path = HttpUtility.UrlDecode(Request.Path.Value, Encoding.UTF8),
                                Para = HttpUtil.GetInputPara(Request),
                                Message = ExceptionUtil.GetInnerestMessage(e),
                                StackTrace = e.StackTrace,
                                ClientIP = HttpUtil.GetClientIP(Request),
                                CreatedAt = DateTime.Now
                            };
                            LogService.AddExceptionLog(exception);
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
        public ActionResult Edit(OrderDto input)
        {
            var result = new BaseOutput();
            if (input.Status == OrderStatus.Success || input.Status == OrderStatus.Refused || input.Status == OrderStatus.Canceled)
            {
                SetResponse(s => s.OrderFinished, result);
            }
            else if (input.Details == null || !input.Details.Any() || input.Details.Any(a => a.Id <= 0))
            {
                SetResponse(s => s.DetailIdNotValid, result);
            }
            else if (input.Details.Any(a => a.ActualPrice < 0))
            {
                SetResponse(s => s.ActualPriceNotValid, result);
            }
            else if (input.Details.Any(a => a.ActualWeight < 0))
            {
                SetResponse(s => s.ActualWeightNotValid, result);
            }
            else if (input.Details.Any(a => a.ActualMoney < 0))
            {
                SetResponse(s => s.ActualMoneyNotValid, result);
            }
            else
            {
                var repo = GetRepo<Order>();
                var detailRepo = GetRepo<OrderDetail>();
                var model = repo.Get(input.Id);
                if (model == null)
                {
                    SetResponse(s => s.OrderNotExisted, result);
                }
                else if (model.CompId != CookieUser.CompId)
                {
                    SetResponse(s => s.NotSelfOrder, result);
                }
                else
                {
                    var detailModelList = detailRepo.GetFiltered(f => f.OrderId == input.Id, true).ToList();
                    if (!detailModelList.Any())
                    {
                        SetResponse(s => s.NoOrderDetail, result);
                    }
                    else if (detailModelList.Select(s => s.Id).Union(input.Details.Select(s => s.Id)).Distinct().Count() != detailModelList.Count)
                    {
                        SetResponse(s => s.DetailIdNotValid, result);
                    }
                    else
                    {
                        foreach (var item in detailModelList)
                        {
                            var currentDetail = input.Details.First(f => f.Id == item.Id);
                            item.ActualPrice = currentDetail.ActualPrice;
                            item.ActualWeight = currentDetail.ActualWeight;
                            item.ActualMoney = currentDetail.ActualMoney;
                        }
                        model.ActualMoney = detailModelList.Sum(s => s.ActualMoney);
                        model.Status = OrderStatus.Success;
                        model.ModifiedAt = DateTime.Now;
                        repo.UnitOfWork.SaveChanges();
                        SetResponse(s => s.Success, result);
                    }
                }
            }
            return JsonNet(result);
        }
        public ActionResult ChangeStatus(int id, int status)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Order>();
            var model = repo.Get(id);
            if (model == null)
            {
                SetResponse(s => s.OrderNotExisted, result);
            }
            else if (model.CompId != CookieUser.CompId)
            {
                SetResponse(s => s.NotSelfOrder, result);
            }
            else if (model.Status == OrderStatus.Success || model.Status == OrderStatus.Refused || model.Status == OrderStatus.Canceled)
            {
                SetResponse(s => s.OrderFinished, result);
            }
            else
            {
                model.Status = status;
                model.ModifiedAt = DateTime.Now;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, result);
            }
            return JsonNet(result);
        }
        public ActionResult GetMyOrderList(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var repo = GetRepo<Order>();
            Expression<Func<Order, bool>> myFilter = ExpressionBuilder.Where<Order>(f => f.CreatedBy == UserId);
            if (!string.IsNullOrEmpty(input.CompName))
            {
                myFilter = myFilter.And(f => f.CompName.Contains(input.CompName));
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
            }
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false).ToList();
            if (list.Any())
            {
                result.total = total;
                var dtoList = MapTo<List<OrderDto>>(list);
                var detailRepo = GetRepo<OrderDetail>();
                var idList = list.Select(s => s.Id).ToList();
                var detailList = detailRepo.GetFiltered(f => idList.Contains(f.OrderId)).Select(s => new { s.ProductName, s.OrderId, s.PreWeight, s.ActualWeight }).ToList();
                foreach (var item in dtoList)
                {
                    item.CanModify = item.CompId == CookieUser.CompId;
                    var details = detailList.Where(f => f.OrderId == item.Id).Select(s => new OrderDetailDto
                    {
                        ProductName = s.ProductName,
                        PreWeight = s.PreWeight,
                        ActualWeight = s.ActualWeight
                    });
                    item.Details = details.ToList();
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult GetOrderCount(int compId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Order>();
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            result.data = repo.GetFiltered(f => f.CompId == compId && f.CreatedAt >= startDate).Count();
            SetResponse(s => s.Success, result);
            return JsonNet(result);
        }
    }
}