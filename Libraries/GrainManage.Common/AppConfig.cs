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
            return System.Configuration.ConfigurationManager.AppSettings[key];
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
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}