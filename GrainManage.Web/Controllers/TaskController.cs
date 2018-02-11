using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Cache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class TaskController : BaseController
    {
        [AllowAnonymous, CheckIP]
        public IActionResult ActivateUser()
        {
            var userRepo = GetRepo<User>();
            Expression<Func<User, bool>> myFilter = ExpressionBuilder.Where<User>(f => f.AppId == 0 && f.CreatedBy > 0);
            var list = userRepo.GetFiltered(myFilter, true).ToList();
            if (list.Any())
            {
                foreach (var item in list)
                {
                    if (item.Roles != null && item.Roles.Any())
                    {
                        var array = item.Roles.Split(",");
                        if (array.Any(a => a == "3"))
                        {
                            item.AppId = item.Id;
                        }
                        else if (array.Any(a => a == "5"))
                        {
                            item.AppId = item.CreatedBy;
                        }
                    }
                }
            }
            return Content($"激活商户：本次共获取到{list.Count}条数据");
        }
        [AllowAnonymous, CheckIP]
        public IActionResult RefreshDbUrl()
        {
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
                    var model = list.FirstOrDefault(a => string.Equals(a.Url, url, StringComparison.CurrentCultureIgnoreCase));
                    if (model == null)
                    {
                        added++;
                        urlRepo.Add(new Address
                        {
                            Url = url,
                            IsWatching = false,//不监控
                            IsValid = true,//有效地址
                            TypeId = typeId,
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
            var invalidList = list.Where(f => !urlList.Any(a => string.Equals(a, f.Url, StringComparison.CurrentCultureIgnoreCase)));
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
            return Content($"更新地址：共获取到{list.Count}条数据，新增{added}条，更新{modified}条，失效{invalid}条");
        }
        [AllowAnonymous, CheckIP]
        public IActionResult RefreshCacheUrl()
        {
            UrlCache.RefreshUrlList(true);
            return Content($"更新Url缓存成功");
        }
    }
}