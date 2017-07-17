using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web;

namespace GrainManage.Web
{
    public class HttpUtil
    {
        public static bool IsIPv4(string ip)
        {
            //利用正则表达式判断字符串是否符合IPv4格式  
            return Regex.IsMatch(ip, "^[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}$");
        }
        public static string RequestHostAddress
        {
            get
            {
                var request = HttpContext.Current.Request;
                string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Split(',')[0];
                }
                if (string.IsNullOrEmpty(result))
                {
                    result = request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.IsNullOrEmpty(result))
                {
                    result = request.UserHostAddress;
                }
                if (string.IsNullOrEmpty(result) || !IsIPv4(result))
                {
                    result = string.Join(",", GetLocalIP());
                }
                return result;
            }
        }
        public static string RemoteAddr
        {
            get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
        }
        public static string XForwardedFor
        {
            get { return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; }
        }
        public static string UserHostAddress
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }

        /// <summary>
        /// 当应用部署为子网站时，可通过此种方法获取到包含子应用的相对地址
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string GetUrl(string relativeUrl)
        {
            return string.Format("{0}/{1}", HttpContext.Current.Request.ApplicationPath.TrimEnd('/'), relativeUrl.Trim('/'));
        }

        /// <summary>
        /// 获取本机所有IPv4地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIP()
        {
            string hostName = Dns.GetHostName();    //得到计算机名  
            var ipEntry = Dns.GetHostEntry(hostName); //得到本机IP地址数组  
            return ipEntry.AddressList.Where(f => f.AddressFamily == AddressFamily.InterNetwork).Select(s => s.ToString()).ToList();
        }
    }
}