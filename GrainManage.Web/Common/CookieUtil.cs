using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void WriteCookie(string strName, string strValue, int expires = 0)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strKey">键</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(分钟),默认60分钟</param>
        public static void WriteCookie(string strName, string strKey, string strValue, int expires = 60)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[strKey] = UrlEncode(strValue);
            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="strName"></param>
        public static void DeleteCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            var cookies = HttpContext.Current.Request.Cookies;
            return cookies != null && cookies[strName] != null ? UrlDecode(cookies[strName].Value) : string.Empty;
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strKey">键</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string strKey)
        {
            var cookies = HttpContext.Current.Request.Cookies;
            return cookies != null && cookies[strName] != null && cookies[strName][strKey] != null ? UrlDecode(cookies[strName][strKey]) : string.Empty;
        }

        private static string UrlEncode(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : HttpContext.Current.Server.UrlEncode(str.Replace("'", ""));
        }

        private static string UrlDecode(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : HttpContext.Current.Server.UrlDecode(str);
        }
    }
}