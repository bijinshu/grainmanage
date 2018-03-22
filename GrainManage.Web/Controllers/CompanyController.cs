﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataBase.GrainManage.Models;
using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Encrypt;
using GrainManage.Web.Common;
using GrainManage.Web.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class CompanyController : BaseController
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
        public ActionResult New(CompanyDto input, IFormFile imgFile)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            if (string.IsNullOrEmpty(input.Name))
            {
                SetResponse(s => s.CompanyNameEmpty, result);
            }
            else if (repo.GetFiltered(f => f.Name == input.Name).Any())
            {
                SetResponse(s => s.CompanyNameExisted, result);
            }
            else
            {
                SetEmptyIfNull(input);
                var userRepo = GetRepo<User>();
                var comp = MapTo<Company>(input);
                comp.CreatedAt = DateTime.Now;
                comp.UserId = UserId;
                if (imgFile != null && imgFile.Length > 0)
                {
                    comp.ImgName = MD5Encrypt.Encrypt(imgFile.OpenReadStream()) + Path.GetExtension(imgFile.FileName);
                    comp.Logo = comp.Logo;
                    var filePath = GetImagePath(comp.ImgName);
                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                    var logoPath = GetLogoPath(comp.Logo);
                    if (!System.IO.File.Exists(logoPath))
                    {
                        ImageUtil.BuildCompLogo(filePath, logoPath);
                    }
                }
                using (var trans = repo.UnitOfWork.BeginTransaction())
                {
                    comp = repo.Add(comp);
                    var user = userRepo.Get(UserId);
                    user.CompId = comp.Id;
                    userRepo.UnitOfWork.SaveChanges();
                    if (comp != null && comp.Id > 0)
                    {
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                if (comp != null && comp.Id > 0)
                {
                    var userInfo = CurrentUser;
                    userInfo.CompId = comp.Id;
                    var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                    Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId, CookieUser.Agent), userInfo, expireAt);
                    result.data = comp.Id;
                }
                SetResponse(s => s.Success, result);
            }
            return JsonNet(result, true);
        }
        public ActionResult Edit(CompanyDto input, IFormFile imgFile)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<Company>();
            if (repo.GetFiltered(f => f.Name == input.Name && f.Id != input.Id).Any())
            {
                SetResponse(s => s.CompanyNameExisted, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                if (model.UserId == UserId)
                {
                    var oldFileName = model.ImgName;
                    model.Name = input.Name;
                    model.Address = input.Address;
                    if (imgFile != null && imgFile.Length > 0)
                    {
                        model.ImgName = MD5Encrypt.Encrypt(imgFile.OpenReadStream()) + Path.GetExtension(imgFile.FileName);
                        model.Logo = model.ImgName;
                        var filePath = GetImagePath(model.ImgName);
                        if (!System.IO.File.Exists(filePath))
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                imgFile.CopyTo(stream);
                            }
                        }
                        var logoPath = GetLogoPath(model.Logo);
                        if (!System.IO.File.Exists(logoPath))
                        {
                            ImageUtil.BuildCompLogo(filePath, logoPath);
                        }
                    }
                    model.ModifiedAt = DateTime.Now;
                    repo.UnitOfWork.SaveChanges();
                    SetResponse(s => s.Success, input, result);
                }
                else
                {
                    SetResponse(s => s.UpdateFailed, input, result);
                }
            }
            return JsonNet(result);
        }
        public ActionResult Delete(int comId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            var model = repo.GetFiltered(f => f.Id == comId).FirstOrDefault();
            if (model != null)
            {
                if (IsSuperAdmin)
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
                SetResponse(s => s.UserNotExist, result);
            }
            return JsonNet(result);
        }
        public ActionResult DeleteFile(int compId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<Company>();
            var model = repo.GetFiltered(f => f.Id == compId, true).FirstOrDefault();
            if (model != null)
            {
                if (model.UserId == UserId)
                {
                    var oldImgName = model.ImgName;
                    model.ImgName = string.Empty;
                    model.Logo = string.Empty;
                    repo.UnitOfWork.SaveChanges();
                    SetResponse(s => s.Success, result);
                }
                else
                {
                    SetResponse(s => s.DeleteFailed, result);
                }
            }
            else
            {
                SetResponse(s => s.CompanyNotExisted, result);
            }
            return JsonNet(result);
        }
        private static string GetImagePath(string fileName)
        {
            return Path.Combine(AppConfig.GetValue("ImagePath"), "company", fileName);
        }
        private static string GetLogoPath(string fileName)
        {
            return Path.Combine(AppConfig.GetValue("ImagePath"), "company", "logo", fileName);
        }
    }
}