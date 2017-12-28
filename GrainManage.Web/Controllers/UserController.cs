using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Web.Models.User;
using GrainManage.Web.Common;
using Microsoft.AspNetCore.Authorization;
using DataBase.GrainManage.Models;
using GrainManage.Web;
using GrainManage.Encrypt;
using GrainManage.Common;
using GrainManage.Web.Models;
using System.Text.RegularExpressions;
using GrainManage.Web.Services;
using DataBase.GrainManage.Models.Log;
using System.Linq.Expressions;
using GrainManage.Core;

namespace GrainManage.Web.Controllers
{
    public class UserController : BaseController
    {
        [AllowAnonymous]
        public ActionResult SignIn(InputSignIn input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            if (string.IsNullOrEmpty(input.UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Pwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var level = 0;
                var account = repo.GetFiltered(f => f.UserName == input.UserName, true).FirstOrDefault();
                if (account != null)
                {
                    if (account.Status == Status.Enabled)
                    {
                        var encryptedPwd = SHAEncrypt.SHA1(input.Pwd);
                        if (account.Pwd != encryptedPwd)
                        {
                            SetResponse(s => s.NamePwdNotMatch, input, result);
                        }
                        else
                        {
                            account.ModifiedAt = DateTime.Now;
                            result.data = new { token = RandomGenerator.Next(20), url = UrlVar.Home_Index };
                            var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                            var userInfo = new UserInfo
                            {
                                UserId = account.Id,
                                UserName = input.UserName,
                                Roles = account.Roles.Split(',').Select(s => int.Parse(s)).ToArray(),
                                Token = result.data.token,
                                ExpiredAt = expireAt.ToString("yyyy-MM-dd HH:mm:ss"),
                                LoginIP = HttpUtil.GetRequestHostAddress(Request)
                            };
                            userInfo.Level = RoleService.GetMaxLevel(userInfo.Roles);
                            userInfo.Auths = CommonService.GetAuths(userInfo.Roles);
                            userInfo.Urls = CommonService.GetUrls(userInfo.Roles);
                            Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId), userInfo, expireAt);
                            var dic = new Dictionary<string, string>();
                            dic[GlobalVar.UserId] = userInfo.UserId.ToString();
                            dic[GlobalVar.UserName] = userInfo.UserName;
                            dic[GlobalVar.Level] = userInfo.Level.ToString();
                            dic[GlobalVar.AuthToken] = userInfo.Token;
                            CookieUtil.WriteCookie(Response.Cookies, GlobalVar.CookieName, dic);
                            level = userInfo.Level;
                            SetResponse(s => s.Success, input, result);
                        }
                    }
                    else
                    {
                        SetResponse(s => s.UserForbidden, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.NameNotExist, input, result);
                }
                LogService.AddLoginLog(new LoginLog { UserName = input.UserName, LoginIP = HttpUtil.GetRequestHostAddress(Request), Status = result.msg, Level = level });
            }
            return JsonNet(result);
        }

        [AllowAnonymous]
        public ActionResult Register(InputRegister input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            var repo = GetRepo<User>();
            if (!(IsUserNameMatch(input.UserName) || IsPhoneMatch(input.Mobile)))
            {
                SetResponse(s => s.NameNotValid, input, result);
            }
            else if (string.IsNullOrEmpty(input.Pwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.UserName == input.UserName).Any())
            {
                SetResponse(s => s.NameExist, input, result);
            }
            else
            {
                if (string.IsNullOrEmpty(input.Email) || IsEmailMatch(input.Email))
                {
                    var model = DynamicMap<User>(input);
                    model.Pwd = SHAEncrypt.SHA1(input.Pwd);
                    model.CreatedAt = DateTime.Now;
                    model.ModifiedAt = DateTime.Now;
                    repo.Add(model);
                    SetResponse(s => s.Success, input, result);
                }
                else
                {
                    SetResponse(s => s.EmailFormatNotMatch, input, result);
                }
            }
            return JsonNet(result);
        }

        [AllowAnonymous]
        public ActionResult ResetPwd(InputResetPassword input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            if (string.IsNullOrEmpty(input.UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Email))
            {
                SetResponse(s => s.EmailEmpty, input, result);
            }
            else if (!IsEmailMatch(input.Email))
            {
                SetResponse(s => s.EmailFormatNotMatch, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.UserName == input.UserName, true).FirstOrDefault();
                if (account != null)
                {
                    if (account.Status == Status.Enabled)
                    {
                        if (account.Email != input.Email)
                        {
                            SetResponse(s => s.EmailNotMatch, input, result);
                        }
                        else
                        {
                            var newPwd = RandomGenerator.Next(8);
                            account.Pwd = SHAEncrypt.SHA1(newPwd);
                            account.ModifiedAt = DateTime.Now;
                            var title = "您的密码已经设置更改";
                            var body = $"{CurrentUser.UserName},您的新密码为:{newPwd},请注意保存";
                            var password = DESEncrypt.Decrypt(AppConfig.GetValue("Password"));
                            var smtp = new EmailUtil(AppConfig.GetValue("From"), password);
                            smtp.SendAsync(input.Email, body, title);
                            repo.UnitOfWork.SaveChanges();
                            SetResponse(s => s.Success, input, result);
                        }
                    }
                    else
                    {
                        SetResponse(s => s.UserForbidden, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.NameNotExist, input, result);
                }
            }
            return JsonNet(result);
        }

        public ActionResult SignOut()
        {
            CookieUtil.DeleteCookie(Response.Cookies, GlobalVar.CookieName);
            var repo = GetRepo<User>();
            var account = repo.GetFiltered(f => f.Id == UserId, true).First();
            account.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            Resolve<ICache>().Remove(CacheKey.GetUserKey(UserId));
            if (IsGetRequest)
            {
                return RedirectToAction("SignIn");
            }
            var result = new BaseOutput();
            SetResponse(s => s.Success, null, result);
            return JsonNet(result);
        }

        public ActionResult ChangePwd(InputChangePassword input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            if (string.IsNullOrEmpty(input.OldPwd) || string.IsNullOrEmpty(input.NewPwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.Id == UserId, true).FirstOrDefault();
                if (account != null && account.Status == Status.Enabled)
                {
                    if (account.Pwd == SHAEncrypt.SHA1(input.OldPwd))
                    {
                        var newStoredPwd = SHAEncrypt.SHA1(input.NewPwd);
                        account.Pwd = newStoredPwd;
                        account.ModifiedAt = DateTime.Now;
                        repo.UnitOfWork.SaveChanges();
                        SetResponse(s => s.Success, input, result);
                    }
                    else
                    {
                        SetResponse(s => s.OldPwdNotMatch, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.UserForbidden, input, result);
                }
            }
            return JsonNet(result);
        }
        public ActionResult Index(InputSearch input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var userRepo = GetRepo<User>();
            Expression<Func<User, bool>> myFilter = ExpressionBuilder.Where<User>(f => f.Id != UserId);
            if (!string.IsNullOrEmpty(input.UserName))
            {
                myFilter = myFilter.And(f => f.UserName.Contains(input.UserName));
            }
            if (!string.IsNullOrEmpty(input.RealName))
            {
                myFilter = myFilter.And(f => f.RealName.Contains(input.RealName));
            }
            if (!string.IsNullOrEmpty(input.Mobile))
            {
                myFilter = myFilter.And(f => f.Mobile.Contains(input.Mobile));
            }
            if (input.Status.HasValue)
            {
                myFilter = myFilter.And(f => f.Status == input.Status);
            }
            int total = 0;
            var now = DateTime.Now;
            var list = userRepo.GetPaged(out total, input.PageIndex, input.PageSize, myFilter).ToList();
            result.total = total;
            var dtoList = MapTo<List<UserDto>>(list);
            if (dtoList.Any())
            {
                var roleRepo = GetRepo<Role>();
                var roleIdList = dtoList.SelectMany(s => s.Roles).Distinct().ToList();
                var roleList = roleRepo.GetFiltered(f => roleIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                foreach (var item in dtoList)
                {
                    item.Pwd = null;
                    var roleNames = string.Join(",", roleList.Where(f => item.Roles.Contains(f.Id)).Select(s => s.Name));
                    item.RoleNames = roleNames;
                }
                result.data = dtoList;
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result,true);
        }
        public ActionResult New(UserDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<User>();
            if (string.IsNullOrEmpty(input.UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Pwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else if (repo.GetFiltered(f => f.UserName == input.UserName).Any())
            {
                SetResponse(s => s.NameExist, input, result);
            }
            else
            {
                var now = DateTime.Now;
                var model = MapTo<User>(input);
                model.Pwd = SHAEncrypt.SHA1(input.Pwd);
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
        public ActionResult Edit(UserDto input)
        {
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<User>();
            if (repo.GetFiltered(f => f.UserName == input.UserName && f.Id != input.Id).Any())
            {
                SetResponse(s => s.NameExist, input, result);
            }
            else
            {
                var model = repo.GetFiltered(f => f.Id == input.Id, true).First();
                model.UserName = input.UserName;
                model.RealName = input.RealName;
                model.Mobile = input.Mobile;
                model.QQ = input.QQ;
                model.Email = input.Email;
                model.Weixin = input.Weixin;
                model.Gender = input.Gender;
                model.Status = input.Status;
                model.Roles = input.Roles != null && input.Roles.Any() ? string.Join(",", input.Roles) : string.Empty;
                model.Remark = input.Remark;
                model.ModifiedAt = DateTime.Now;
                repo.UnitOfWork.SaveChanges();
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        public ActionResult Delete(int userId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<User>();
            var model = repo.GetFiltered(f => f.Id == userId).FirstOrDefault();
            if (model != null)
            {
                repo.Delete(model);
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.UserNotExist, result);
            }
            return JsonNet(result);
        }
        public ActionResult Info()
        {
            var result = new BaseOutput();
            var userRepo = GetRepo<User>();
            var user = userRepo.GetFiltered(f => f.Id == UserId).First();
            var dto = MapTo<UserDto>(user);
            dto.Pwd = null;
            if (!string.IsNullOrEmpty(user.Roles))
            {
                var roleRepo = GetRepo<Role>();
                var roles = roleRepo.GetFiltered(f => dto.Roles.Contains(f.Id)).Select(s => s.Name).ToList();
                dto.RoleNames = string.Join(",", roles);
            }
            result.data = dto;
            SetResponse(s => s.Success, result);
            return JsonNet(result);
        }

        private bool IsEmailMatch(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{1,4}$");
        }
        private bool IsUserNameMatch(string userName)
        {
            return !string.IsNullOrEmpty(userName) && Regex.IsMatch(userName, @"^[a-zA-Z0-9-_]{2,20}$");
        }
        private bool IsPhoneMatch(string phone)
        {
            return !string.IsNullOrEmpty(phone) && Regex.IsMatch(phone, @"^1[34578]\d{9}$");
        }
    }
}
