using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrainManage.Web.Models.Account;
using GrainManage.Web.Common;
using System.Web.Security;
using DataBase.GrainManage.Models;
using GrainManage.Web;
using GrainManage.Encrypt;
using GrainManage.Common;
using GrainManage.Web.Models;
using System.Text.RegularExpressions;
using GrainManage.Web.Services;

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
                                LoginIP = HttpUtil.RequestHostAddress
                            };
                            userInfo.Level = RoleService.GetMaxLevel(userInfo.Roles);
                            userInfo.Auths = CommonService.GetAuths(userInfo.Roles);
                            userInfo.Urls = CommonService.GetUrls(userInfo.Roles);
                            Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId), userInfo, expireAt);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.UserId, userInfo.UserId.ToString());
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.UserName, userInfo.UserName);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.Level, userInfo.Level.ToString());
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.AuthToken, userInfo.Token);
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
                LogService.AddLoginLog(new LoginLog { UserName = input.UserName, LoginIP = HttpUtil.RequestHostAddress, Status = result.msg, Level = level });
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
            if (!(IsUserNameMatch(input.UserName) || IsPhoneMatch(input.CellPhone)))
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
        public ActionResult ResetPassword(InputResetPassword input)
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
                            var body = string.Format("{0},您的新密码为:{1},请注意保存");
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
            CookieUtil.DeleteCookie(GlobalVar.CookieName);
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

        public ActionResult ChangePassword(InputChangePassword input)
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
