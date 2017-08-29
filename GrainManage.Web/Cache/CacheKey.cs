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
        public static string GetUserKey(int userId)
        {
            return string.Format("user_{0}", userId);
        }
        public static string GetResourceKey(int userId)
        {
            return string.Format("resource_{0}", userId);
        }
    }
}