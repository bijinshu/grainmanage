using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Encrypt;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using GrainManage.Web.Models.User;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace GrainManage.Web.Controllers
{
    public class UserController : BaseController
    {
        [AllowAnonymous]
        public ActionResult SignIn(InputSignIn input, string returnUrl)
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
                var logModel = new LoginLog { UserName = input.UserName, LoginIP = HttpUtil.GetRequestHostAddress(Request) };
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.UserName == input.UserName).FirstOrDefault();
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
                            var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                            var userInfo = new UserInfo
                            {
                                UserId = account.Id,
                                CompId = account.CompId,
                                UserName = input.UserName,
                                Roles = account.Roles.Split(',').Select(s => int.Parse(s)).ToArray(),
                                Token = RandomGenerator.Next(20),
                                ExpiredAt = expireAt.ToString("yyyy-MM-dd HH:mm:ss"),
                                LoginIP = HttpUtil.GetRequestHostAddress(Request)
                            };
                            userInfo.Level = RoleService.GetMaxLevel(userInfo.Roles);
                            userInfo.Auths = CommonService.GetAuths(userInfo.Roles);
                            userInfo.Urls = CommonService.GetUrls(userInfo.Roles);
                            var agent = string.IsNullOrEmpty(returnUrl) ? 0 : 1;
                            Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId, agent), userInfo, expireAt);
                            UserUtil.WriteToCookie(Response.Cookies, userInfo, agent);
                            logModel.Level = userInfo.Level;
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
                logModel.Status = result.msg;
                LogService.AddLoginLog(logModel);
            }
            return JsonNet(result);
        }

        [AllowAnonymous]
        public ActionResult SignUp(InputRegister input)
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
                    SetEmptyIfNull(model);
                    model.Pwd = SHAEncrypt.SHA1(input.Pwd);
                    if (input.IsShop)
                    {
                        model.CompId = -1;
                        model.Roles = GlobalVar.Role_Shop.ToString();
                    }
                    else
                    {
                        model.Roles = GlobalVar.Role_User.ToString();
                    }
                    model.CreatedAt = DateTime.Now;
                    model.CreatedBy = -1;//系统注册
                    model.ModifiedAt = DateTime.Now;
                    model.Status = Status.Enabled;
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
        public ActionResult ForgetPwd(InputResetPassword input)
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
            CookieUtil.Delete(Response.Cookies, GlobalVar.CookieName);
            var repo = GetRepo<User>();
            var account = repo.GetFiltered(f => f.Id == UserId, true).First();
            account.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            Resolve<ICache>().Remove(CacheKey.GetUserKey(UserId, CookieUser.Agent));
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
                return View(CurrentUser);
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
            var now = DateTime.Now;
            var list = userRepo.GetPaged(out int total, input.PageIndex, input.PageSize, myFilter, o => o.Id, false).ToList();
            if (list.Any())
            {
                result.total = total;
                var dtoList = MapTo<List<UserDto>>(list);
                var roleRepo = GetRepo<Role>();
                var roleIdList = dtoList.SelectMany(s => s.Roles).Distinct().ToList();
                var roleList = roleRepo.GetFiltered(f => roleIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                var compRepo = GetRepo<Company>();
                var compIdList = list.Select(s => s.CompId).Distinct().ToList();
                var compList = compRepo.GetFiltered(f => compIdList.Contains(f.Id)).Select(s => new { s.Id, s.Name }).ToList();
                foreach (var item in dtoList)
                {
                    item.Pwd = null;
                    var roleNames = string.Join(",", roleList.Where(f => item.Roles.Contains(f.Id)).Select(s => s.Name));
                    item.RoleNames = roleNames;
                    var comp = compList.FirstOrDefault(f => f.Id == item.CompId);
                    if (comp != null)
                    {
                        item.CompName = comp.Name;
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
                model.CreatedBy = UserId;
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
                model.Address = input.Address;
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
        public ActionResult UpdateSelf(UserDto input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            SetEmptyIfNull(input);
            var repo = GetRepo<User>();
            var model = repo.GetFiltered(f => f.Id == UserId, true).First();
            model.RealName = input.RealName;
            model.Mobile = input.Mobile;
            model.QQ = input.QQ;
            model.Email = input.Email;
            model.Weixin = input.Weixin;
            model.Gender = input.Gender;
            model.Address = input.Address;
            model.ModifiedAt = DateTime.Now;
            repo.UnitOfWork.SaveChanges();
            SetResponse(s => s.Success, input, result);
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
            Company comp = null;
            if (user.CompId > 0)
            {
                comp = GetRepo<Company>().GetFiltered(f => f.Id == user.CompId).FirstOrDefault();
            }
            if (comp == null)
            {
                result.data = new { dto.UserName, dto.RealName, dto.Gender, dto.Mobile, dto.QQ, dto.Weixin, dto.Email, dto.RoleNames, dto.CompId };
            }
            else
            {
                result.data = new { dto.UserName, dto.RealName, dto.Gender, dto.Mobile, dto.QQ, dto.Weixin, dto.Email, dto.RoleNames, dto.CompId, ShopName = comp.Name, ShopAddress = comp.Address, comp.ImgName };
            }
            SetResponse(s => s.Success, result);
            return JsonNet(result, true);
        }
        public ActionResult SimpleInfo()
        {
            var result = new BaseOutput();
            var userRepo = GetRepo<User>();
            var user = userRepo.GetFiltered(f => f.Id == UserId).First();
            result.data = new { user.Mobile, user.Address };
            SetResponse(s => s.Success, result);
            return JsonNet(result, true);
        }
        public ActionResult SelfInfo()
        {
            var result = new BaseOutput();
            var userRepo = GetRepo<User>();
            var user = userRepo.GetFiltered(f => f.Id == UserId).First();
            result.data = new { user.RealName, user.QQ, user.Weixin, user.Mobile, user.Gender, user.Address, user.Email };
            SetResponse(s => s.Success, result);
            return JsonNet(result, true);
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
