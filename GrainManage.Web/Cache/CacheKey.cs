using GrainManage.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GrainManage.Web
{
    public class CacheKey
    {
        public static string GetUserKey(int userId, int agent)
        {
            return string.Format("user_{0}_{1}", userId, agent);
        }
        public static string GetResourceKey(int userId)
        {
            return string.Format("resource_{0}", userId);
        }
        public static string GetUrlKey(string ip)
        {
            return string.Format("watching_url_{0}", ip);
        }
    }
}