using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Core;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Web.Models.WhiteIp;

namespace GrainManage.Web.Controllers
{
    public class WhiteIpController : BaseController
    {
        public IActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            var productRepo = GetRepo<WhiteIP>();
            Expression<Func<WhiteIP, bool>> myFilter = ExpressionBuilder.Where<WhiteIP>(f => true);
            if (!string.IsNullOrEmpty(input.IP))
            {
                myFilter = myFilter.And(f => f.IP.Contains(input.IP));
            }
            if (input.Status.HasValue)
            {
                myFilter = myFilter.And(f => f.Status == input.Status);
            }
            if (input.StartTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt >= input.StartTime);
            }
            if (input.EndTime.HasValue)
            {
                myFilter = myFilter.And(f => f.CreatedAt <= input.EndTime);
            }
            var list = productRepo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.CreatedAt, false).ToList();
            if (list.Any())
            {
                result.total = total;
                result.data = list;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result, true);
        }
        public IActionResult New(WhiteIP input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<WhiteIP>();
            if (string.IsNullOrEmpty(input.IP) || !HttpUtil.IsIPv4(input.IP))
            {
                SetResponse(s => s.IpNotValid, result);
            }
            else if (repo.GetFiltered(f => f.IP == input.IP).Any())
            {
                SetResponse(s => s.IpExisted, result);
            }
            else
            {
                input.Id = 0;
                input.CreatedAt = DateTime.Now;
                repo.Add(input);
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public IActionResult Edit(WhiteIP input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<WhiteIP>();
            if (string.IsNullOrEmpty(input.IP) || !HttpUtil.IsIPv4(input.IP))
            {
                SetResponse(s => s.IpNotValid, result);
            }
            else if (repo.GetFiltered(f => f.IP == input.IP && f.Id != input.Id).Any())
            {
                SetResponse(s => s.IpExisted, result);
            }
            else
            {
                var model = repo.Get(input.Id);
                model.IP = input.IP;
                model.Status = input.Status;
                model.Remark = input.Remark;
                model.ModifiedAt = DateTime.Now;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public IActionResult Delete(int id)
        {
            var result = new BaseOutput();
            var repo = GetRepo<WhiteIP>();
            var model = repo.GetFiltered(f => f.Id == id).FirstOrDefault();
            if (model != null)
            {
                repo.Delete(model);
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.Failed, result);
            }
            return JsonNet(result);
        }
    }
}