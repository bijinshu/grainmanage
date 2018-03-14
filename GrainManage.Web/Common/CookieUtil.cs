using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GrainManage.Web.Common
{
    public class CookieUtil
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void Write(IResponseCookies cookies, string strName, string strValue, int expires = 0)
        {
            if (expires > 0)
            {
                cookies.Append(strName, strValue, new CookieOptions { Expires = DateTime.Now.AddMinutes(expires) });
            }
            else
            {
                cookies.Append(strName, strValue);
            }
        }
        public static void Write(IResponseCookies cookies, string strName, Dictionary<string, string> dic, int expires = 0)
        {
            Write(cookies, strName, GetCookieStr(dic), expires);
        }
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="strName"></param>
        public static void Delete(IResponseCookies cookies, string strName)
        {
            cookies.Delete(strName);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string Get(IRequestCookieCollection cookies, string strName)
        {
            return cookies != null && cookies[strName] != null ? cookies[strName]: string.Empty;
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strKey">键</param>
        /// <returns>cookie值</returns>
        public static string Get(IRequestCookieCollection cookies, string strName, string strKey)
        {
            if (cookies != null && cookies[strName] != null)
            {
                var str = cookies[strName];
                var queryList = str.Split('&');
                if (queryList != null && queryList.Any())
                {
                    foreach (var query in queryList)
                    {
                        var item = query.Split('=');
                        if (item[0] == strKey)
                        {
                            return UrlDecode(item?[1]);
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static T Get<T>(IRequestCookieCollection cookies, string strName, string strKey)
        {
            T result = default(T);
            try
            {
                var strValue = Get(cookies, strName, strKey);
                if (!string.IsNullOrWhiteSpace(strValue))
                {
                    result = (T)Convert.ChangeType(strValue, typeof(T));
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        private static string UrlEncode(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : HttpUtility.UrlEncode(str, Encoding.UTF8);
        }

        private static string UrlDecode(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : HttpUtility.UrlDecode(str, Encoding.UTF8);
        }
        public static string GetCookieStr(Dictionary<string, string> dic)
        {
            return string.Join("&", dic.Select(s => $"{s.Key}={UrlEncode(s.Value)}"));
        }
    }
}