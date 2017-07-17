using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GrainManage.Web
{
    public class CacheKey
    {
        public static string GetSafeInfoKey(string userName)
        {
            return string.Format("SafeInfo_{0}", userName);
        }
        public static string GetApiResourceKey(string userName)
        {
            return string.Format("ApiResource_{1}", userName);
        }
    }
}