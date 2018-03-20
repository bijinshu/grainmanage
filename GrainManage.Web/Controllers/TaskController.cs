using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Web.Cache;
using GrainManage.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GrainManage.Web.Controllers
{
    public class TaskController : BaseController
    {
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
            return Content($"更新地址：共获取到{list.Count}条数据，新增{added}条，更新{modified}条，失效{invalid}条");
        }
        [AllowAnonymous, CheckIP]
        public IActionResult RefreshCacheUrl()
        {
            UrlCache.RefreshUrlList(true);
            return Content($"更新Url缓存成功");
        }

        [AllowAnonymous, CheckIP]
        public IActionResult DeleteCompLogo()
        {
            var result = new BaseOutput();
            var dir = Path.Combine(AppConfig.GetValue("ImagePath"), "company");
            var success = 0;
            var failed = 0;
            var total = 0;
            //删除img文件
            var imgFiles = Directory.GetFiles(dir);
            total = imgFiles.Length;
            var repo = GetRepo<Company>();
            foreach (var filePath in imgFiles)
            {
                var fileName = Path.GetFileName(filePath);
                if (!repo.GetFiltered(f => f.ImgName == fileName).Any())
                {
                    try
                    {
                        System.IO.File.Delete(filePath);
                        success++;
                    }
                    catch (Exception)
                    {
                        failed++;
                    }
                }
            }
            //删除logo文件
            dir = Path.Combine(dir, "logo");
            var logoFiles = Directory.GetFiles(dir);
            total += logoFiles.Length;
            foreach (var filePath in logoFiles)
            {
                var fileName = Path.GetFileName(filePath);
                if (!repo.GetFiltered(f => f.Logo == fileName).Any())
                {
                    try
                    {
                        System.IO.File.Delete(filePath);
                        success++;
                    }
                    catch (Exception)
                    {
                        failed++;
                    }
                }
            }
            SetResponse(s => s.Success, result, $"共发现{total}个文件，其中有效文件{total - success - failed}个，成功删除{success}个，删除失败{failed}个");
            return JsonNet(result);
        }

        [AllowAnonymous, CheckIP]
        public IActionResult BuildCompLogo()
        {
            var result = new BaseOutput();
            var dir = Path.Combine(AppConfig.GetValue("ImagePath"), "company");
            var success = 0;
            var ignored = 0;
            var total = 0;
            var repo = GetRepo<Company>();
            var compList = repo.GetFiltered(f => f.ImgName != "" && f.Logo == "", true).ToList();
            total = compList.Count;
            foreach (var comp in compList)
            {
                var imgPath = Path.Combine(dir, comp.ImgName);
                var logoPath = Path.Combine(dir, "logo", comp.ImgName);
                if (System.IO.File.Exists(imgPath) && !System.IO.File.Exists(logoPath))
                {
                    ImageUtil.BuildCompLogo(imgPath, logoPath);
                }
                comp.Logo = comp.ImgName;
            }
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, result, $"共发现{total}条记录需要生成缩略图，成功生成{success}个，无需生成{ignored}个");
            return JsonNet(result);
        }

    }
}