using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
                    result = GetLocalIP().First();
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
        /// 获取本机所有IPv4地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIP()
        {
            string hostName = Dns.GetHostName();    //得到计算机名  
            var ipEntry = Dns.GetHostEntry(hostName); //得到本机IP地址数组  
            return ipEntry.AddressList.Where(f => f.AddressFamily == AddressFamily.InterNetwork).Select(s => s.ToString()).ToList();
        }

        /// <summary>
        /// 根据请求类型,自动提取请求参数
        /// </summary>
        /// <returns></returns>
        public static string GetInputPara()
        {
            var inputPara = string.Empty;
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                inputPara = HttpUtility.UrlDecode(HttpContext.Current.Request.Url.Query.TrimStart('?'), Encoding.UTF8);
            }
            else if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                inputPara = GetJson(GetFormData(HttpContext.Current.Request.Form));
            }
            return inputPara ?? string.Empty;
        }
        private static string GetJson(object obj)
        {
            if (obj != null)
            {
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
            }
            return string.Empty;
        }
        private static Dictionary<string, string> GetFormData(NameValueCollection form)
        {
            if (form != null && form.Count > 0)
            {
                var dic = new Dictionary<string, string>();
                foreach (var name in form.AllKeys)
                {
                    dic[name] = form[name];
                }
                return dic;
            }
            return null;
        }
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}