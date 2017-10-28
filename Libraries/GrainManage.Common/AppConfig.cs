using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Common
{
    public class AppConfig
    {
        public static string GetValue(string key)
        {
            return Handler($"AppSettings:{key}");
        }

        public static T GetValue<T>(string key)
        {
            T result = default(T);
            try
            {
                var strValue = GetValue(key);
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
        public static string GetConnectionString(string name)
        {
            return Handler($"ConnectionStrings:{name}");
        }

        public static Func<string, string> Handler { get; set; }
    }
}