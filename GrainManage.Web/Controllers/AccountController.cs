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

namespace GrainManage.Web.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult SignIn(InputSignIn input)
        {
            var length = Guid.NewGuid().ToString("N");
            if (IsGetRequest)
            {
                CookieUtil.DeleteCookie(GlobalVar.CookieName);
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
                var account = repo.GetFiltered(f => f.UserName == input.UserName, true).FirstOrDefault();
                if (account != null)
                {
                    if (account.Status == UserStatus.Enabled)
                    {
                        var encryptedPwd = SHAEncrypt.SHA1(input.Pwd);
                        if (account.Pwd != encryptedPwd)
                        {
                            SetResponse(s => s.NamePwdNotMatch, input, result);
                        }
                        else
                        {
                            account.LastActive = DateTime.Now;
                            result.data = new { token = RandomGenerator.Next(20), url = HttpUtil.GetUrl("Contact/Index/") };
                            var expireAt = DateTime.Now.AddMinutes(AppConfig.GetValue<double>(GlobalVar.CacheMinute));
                            var userInfo = new UserInfo
                            {
                                UserId = account.Guid,
                                UserName = input.UserName,
                                Token = result.data.token,
                                ExpiredAt = expireAt.ToString("yyyy-MM-dd HH:mm:ss"),
                                LoginIP = HttpUtil.RequestHostAddress
                            };
                            Resolve<ICache>().Set(CacheKey.GetUserKey(userInfo.UserId), userInfo, expireAt);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.UserId, userInfo.UserId);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.UserName, userInfo.UserName);
                            CookieUtil.WriteCookie(GlobalVar.CookieName, GlobalVar.AuthToken, userInfo.Token);
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
                var loginRepository = GetRepo<LoginLog>();
                loginRepository.Add(new LoginLog
                {
                    UserName = input.UserName,
                    LoginIP = HttpUtil.RequestHostAddress,
                    Created = DateTime.Now,
                    Status = result.msg,
                });
            }
            return JsonNet(result);
        }

        public ActionResult SignOut()
        {
            CookieUtil.DeleteCookie(GlobalVar.CookieName);
            var repo = GetRepo<User>();
            var account = repo.GetFiltered(f => f.Guid == UserId, true).First();
            account.LastActive = DateTime.Now;
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
                    if (account.Status == UserStatus.Enabled)
                    {
                        if (account.Email != input.Email)
                        {
                            SetResponse(s => s.EmailNotMatch, input, result);
                        }
                        else
                        {
                            var newPwd = RandomGenerator.Next(8);
                            account.Pwd = SHAEncrypt.SHA1(newPwd);
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
            if (string.IsNullOrEmpty(input.OldPwd) || string.IsNullOrEmpty(input.NewPwd))
            {
                SetResponse(s => s.PwdEmpty, input, result);
            }
            else
            {
                var repo = GetRepo<User>();
                var account = repo.GetFiltered(f => f.Guid == UserId, true).FirstOrDefault();
                if (account != null && account.Status == UserStatus.Enabled)
                {
                    if (account.Pwd == SHAEncrypt.SHA1(input.OldPwd))
                    {
                        var newStoredPwd = SHAEncrypt.SHA1(input.NewPwd);
                        account.Pwd = newStoredPwd;
                        account.LastActive = DateTime.Now;
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
                    SetResponse(s => s.UserNotActivated, input, result);
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
