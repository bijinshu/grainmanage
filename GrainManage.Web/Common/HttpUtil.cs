﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public static bool IsIPv4(string ip)
        {
            //利用正则表达式判断字符串是否符合IPv4格式  
            return Regex.IsMatch(ip, "^[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}$");
        }
        public static string GetRequestHostAddress(HttpRequest request)
        {
            string result = request.Headers["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Split(',')[0];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = request.Headers["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = request.Host.Value;
            }
            if (string.IsNullOrEmpty(result) || !IsIPv4(result))
            {
                result = GetLocalIP().First();
            }
            return result;
        }
        public static string GetRemoteAddr(HttpRequest request)
        {
            return request.Headers["REMOTE_ADDR"];
        }
        public static string GetXForwardedFor(HttpRequest request)
        {
            return request.Headers["HTTP_X_FORWARDED_FOR"];
        }
        public static string GetUserHostAddress(HttpRequest request)
        {
            return request.Host.Value;
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
            else if (request.Method == "POST")
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
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}