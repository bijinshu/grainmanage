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
        public static string GetUserKey(string userName)
        {
            return MD5Encrypt.Encrypt(string.Format("user_{0}", userName));
        }
        public static string GetResourceKey(string userName)
        {
            return MD5Encrypt.Encrypt(string.Format("resource_{0}", userName));
        }
    }
}