using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
        public static bool IsIPv4(string ip)
        {
            //利用正则表达式判断字符串是否符合IPv4格式  
            return Regex.IsMatch(ip, "^(localhost)|[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}$");
        }
        public static string GetRequestHostAddress(HttpRequest request)
        {
            string result = GetHeader(request, "X-Forwarded-For");
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Split(',')[0];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = GetHeader(request, "X-Real-IP");
            }
            if (string.IsNullOrEmpty(result))
            {
                result = GetHeader(request, "Remote_Addr");
            }
            if (string.IsNullOrEmpty(result))
            {
                result = request.Host.Host;
            }
            if (string.IsNullOrEmpty(result) || !IsIPv4(result))
            {
                result = GetLocalIP().Where(f => IsIPv4(f)).FirstOrDefault();
            }
            return result;
        }
        public static string GetHeader(HttpRequest request, string name)
        {
            return request.Headers.Where(f => string.Equals(f.Key, name, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Value).FirstOrDefault();
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
        public static string GetInputPara(HttpRequest request)
        {
            var inputPara = string.Empty;
            if (request.Method == "GET")
            {
                inputPara = HttpUtility.UrlDecode(request.QueryString.Value?.TrimStart('?'), Encoding.UTF8);
            }
            else if (request.Method == "POST" && request.ContentLength > 0)
            {
                inputPara = GetJson(GetFormData(request.Form));
            }
            return inputPara ?? string.Empty;
        }

        public static string GetServerPath(string relativePath)
        {
            if (!Path.IsPathRooted(relativePath))
            {
                return Path.Combine(GlobalVar.ContentRootPath, relativePath);
            }
            return relativePath;
        }
        private static string GetJson(object obj)
        {
            if (obj != null)
            {
                return JsonConvert.SerializeObject(obj, Formatting.None, settings);
            }
            return string.Empty;
        }
        private static Dictionary<string, string> GetFormData(IFormCollection form)
        {
            if (form != null && form.Count > 0)
            {
                var dic = new Dictionary<string, string>();
                foreach (var name in form.Keys)
                {
                    dic[name] = form[name];
                }
                return dic;
            }
            return null;
        }
    }
}