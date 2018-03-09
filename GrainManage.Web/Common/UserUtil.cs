using GrainManage.Common;
using GrainManage.Encrypt;
using GrainManage.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Common
{
    public class UserUtil
    {
        public static CookieUserInfo GetFromCookie(IRequestCookieCollection cookies)
        {
            CookieUserInfo info = null;
            var content = CookieUtil.Get(cookies, GlobalVar.CookieName, GlobalVar.Content);
            var sign = CookieUtil.Get(cookies, GlobalVar.CookieName, GlobalVar.Sign);
            if (!string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(sign))
            {
                var md5Key = AppConfig.GetValue("Md5Key");
                if (sign == MD5Encrypt.Encrypt($"{md5Key}{content}{md5Key}"))
                {
                    try
                    {
                        content = AESEncrypt.Decrypt(content, AppConfig.GetValue("AesKey"));
                        if (!string.IsNullOrEmpty(content))
                        {
                            var arrays = content.Split('|');
                            info = new CookieUserInfo
                            {
                                UserId = int.Parse(arrays[0]),
                                UserName = arrays[1],
                                CompId = int.Parse(arrays[2]),
                                Level = int.Parse(arrays[3]),
                                Token = arrays[4],
                                ExpiredAt = arrays[5],
                                Agent = int.Parse(arrays[6])
                            };
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return info;
        }
        public static void SaveToClient(IResponseCookies cookies, UserInfo u, int agent)
        {
            var content = $"{u.UserId}|{u.UserName}|{u.CompId}|{u.Level}|{u.Token}|{u.ExpiredAt}|{agent}";
            content = AESEncrypt.Encrypt(content, AppConfig.GetValue("AesKey"));
            var md5Key = AppConfig.GetValue("Md5Key");
            var dic = new Dictionary<string, string>();
            dic[GlobalVar.Content] = content;
            dic[GlobalVar.Sign] = MD5Encrypt.Encrypt($"{md5Key}{content}{md5Key}");
            CookieUtil.Write(cookies, GlobalVar.CookieName, dic);
        }
    }
}
