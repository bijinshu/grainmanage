using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Core;
using GrainManage.Web.Cache;
using GrainManage.Web.Models.Address;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class AddressController : BaseController
    {
        public IActionResult Index(InputSearch input)
        {
            var currentUser = CurrentUser;
            if (IsGetRequest)
            {
                return View(currentUser);
            }
            var result = new BaseOutput();
            var productRepo = GetRepo<Address>();
            Expression<Func<Address, bool>> myFilter = ExpressionBuilder.Where<Address>(f => true);
            if (!string.IsNullOrEmpty(input.Remark))
            {
                myFilter = myFilter.And(f => f.Remark.Contains(input.Remark));
            }
            if (!string.IsNullOrEmpty(input.Path))
            {
                myFilter = myFilter.And(f => f.Path.Contains(input.Path));
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
        public IActionResult Edit(Address input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            try
            {
                var repo = GetRepo<Address>();
                var model = repo.Get(input.Path);
                model.IsWatching = input.IsWatching;
                model.Remark = input.Remark;
                model.ModifiedAt = DateTime.Now;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            catch (Exception)
            {
                SetResponse(s => s.Failed, input, result);
            }
            return JsonNet(result);
        }
        public IActionResult RefreshDb()
        {
            var result = new BaseOutput();
            var urlRepo = GetRepo<Address>();
            var urlList = new List<string>();
            var added = 0;
            var modified = 0;
            var invalid = 0;
            var list = urlRepo.GetFiltered(f => true, true).ToList();
            urlRepo.UnitOfWork.LazyCommitEnabled = true;
            foreach (var item in typeof(UrlVar).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                var url = item.GetValue(null) as string;
                var typeId = item.GetCustomAttributes<CommonAttribute>().Any() ? 1 : 0;
                if (!string.IsNullOrEmpty(url))
                {
                    urlList.Add(url);
                    var model = list.FirstOrDefault(a => string.Equals(a.Path, url, StringComparison.CurrentCultureIgnoreCase));
                    if (model == null)
                    {
                        added++;
                        urlRepo.Add(new Address
                        {
                            Path = url,
                            IsWatching = false,//不监控
                            IsValid = true,//有效地址
                            TypeId = typeId,
                            Remark = string.Empty,
                            CreatedAt = DateTime.Now
                        });
                    }
                    else if (model.TypeId != typeId || !model.IsValid)
                    {
                        modified++;
                        model.TypeId = typeId;
                        model.IsValid = true;
                        model.ModifiedAt = DateTime.Now;
                    }
                }
            }
            var invalidList = list.Where(f => !urlList.Any(a => string.Equals(a, f.Path, StringComparison.CurrentCultureIgnoreCase)));
            foreach (var item in invalidList)
            {
                if (item.IsValid)
                {
                    invalid++;
                    item.IsValid = false;
                    item.ModifiedAt = DateTime.Now;
                }
            }
            urlRepo.UnitOfWork.SaveChanges(true);
            result.data = new { Total = list.Count, Added = added, Modified = modified, Invalid = invalid };
            var msg = $"数据库当前有{list.Count}条接口地址，本次新增{added}条，更新{modified}条，失效{invalid}条";
            SetResponse(s => s.Success, result, msg);
            return JsonNet(result);
        }
        public IActionResult RefreshCache()
        {
            var result = new BaseOutput();
            UrlCache.RefreshUrlList(true);
            SetResponse(s => s.Success, result, "成功：如果应用是分布式部署，请重复刷新多次");
            return JsonNet(result);
        }
    }
}