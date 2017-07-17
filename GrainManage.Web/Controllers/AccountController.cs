using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrainManage.Web.Models.Account;
using GrainManage.Web.Resources;
using GrainManage.Web.Common;
using System.Web.Security;
using GrainManage.Web.Util;
using DataBase.GrainManage.Models;
using GrainManage.Web;
using GrainManage.Encrypt;
using GrainManage.Common;
using GrainManage.Web.Models;

namespace GrainManage.Web.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult SignIn(InputSignIn input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            if (string.IsNullOrWhiteSpace(input.UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.Password))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.UserName == input.UserName, true).FirstOrDefault();
                if (account != null)
                {
                    if (account.Status == UserStatus.Enabled)
                    {
                        var encryptedPwd = SHAEncrypt.SHA1(input.Password);
                        if (account.Pwd != encryptedPwd)
                        {
                            SetResponse(s => s.PwdNotMatch, input, result);
                        }
                        else
                        {
                            var now = DateTime.Now;
                            account.LastActive = now;
                            result.data = new
                            {
                                token = RandomGenerator.Next(20),
                                url = HttpUtil.GetUrl("Contact/Index/")
                            };
                            var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                            var safeInfo = new SafeInfo
                            {
                                UserName = input.UserName,
                                Token = result.data.token,
                                ExpiredAt = expireAt,
                                LoginIP = HttpUtil.RequestHostAddress
                            };
                            var cache = Resolve<ICache>();
                            cache.Set(CacheKey.GetSafeInfoKey(input.UserName), safeInfo, expireAt);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.UserName, input.UserName);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.AuthToken, result.data.token);
                            SetResponse(s => s.Success, input, result);
                        }
                    }
                    else
                    {
                        SetResponse(s => s.UserNotActivated, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.NameNotExist, input, result);
                }
            }
            var loginRepository = GetRepo<LoginLog>();
            loginRepository.Add(new LoginLog
            {
                UserName = input.UserName,
                LoginIP = HttpUtil.RequestHostAddress,
                Created = DateTime.Now,
                Status = result.msg,
            });
            return JsonNet(result);
        }

        public ActionResult SignOut()
        {
            CookieUtil.DeleteCookie(GlobalVar.CookieName);
            var userName = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName);
            var authToken = CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken);
            var repo = GetRepo<User>();
            var account = repo.GetFiltered(f => f.UserName == userName, true).First();
            account.LastActive = DateTime.Now;
            account.Guid = Guid.NewGuid().ToString();
            repo.UnitOfWork.SaveChanges();
            var safeInfoKey = CacheKey.GetSafeInfoKey(userName);
            var cache = Resolve<ICache>();
            cache.Remove(safeInfoKey);
            if (IsGetRequest)
            {
                return View("SignIn");
            }
            var result = new BaseOutput();
            SetResponse(s => s.Success, null, result);
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
                if (string.IsNullOrEmpty(input.Email) || IsEmailMatch(input.Email))
                {
                    var model = DynamicMap<User>(input);
                    model.Pwd = SHAEncrypt.SHA256(input.Pwd);
                    model.Created = DateTime.Now;
                    model.LastActive = DateTime.Now;
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
            if (string.IsNullOrWhiteSpace(input.UserName))
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
                    if (account.Status == UserStatus.Enabled)
                    {
                        if (account.Email != input.Email)
                        {
                            SetResponse(s => s.EmailNotMatch, input, result);
                        }
                        else
                        {
                            var newPwd = RandomGenerator.Next(8);
                            account.Pwd = SHAEncrypt.SHA256(newPwd);
                            account.LastActive = DateTime.Now;
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
                        SetResponse(s => s.UserNotActivated, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.NameNotExist, input, result);
                }
            }
            return JsonNet(result);
        }

        public ActionResult ChangePassword(InputChangePassword input)
        {
            if (IsGetRequest)
            {
                return View();
            }
            var result = new BaseOutput();
            if (string.IsNullOrWhiteSpace(UserName))
            {
                SetResponse(s => s.NameEmpty, input, result);
            }
            else if (string.IsNullOrEmpty(input.OldPassword) || string.IsNullOrEmpty(input.NewPassword))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var userName = UserName;
                var account = repo.GetFiltered(f => f.UserName == userName, true).FirstOrDefault();
                if (account != null && account.Status == UserStatus.Enabled)
                {
                    if (account.Pwd == SHAEncrypt.SHA256(input.OldPassword))
                    {
                        var newStoredPwd = SHAEncrypt.SHA256(input.NewPassword);
                        account.Pwd = newStoredPwd;
                        account.LastActive = DateTime.Now;
                        repo.UnitOfWork.SaveChanges();
                        SetResponse(s => s.Success, input, result);
                    }
                    else
                    {
                        SetResponse(s => s.PwdNotMatch, input, result);
                    }
                }
                else
                {
                    SetResponse(s => s.UserNotActivated, input, result);
                }
            }
            return JsonNet(result);
        }

        private bool IsEmailMatch(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{2,4}");
        }
    }
}
