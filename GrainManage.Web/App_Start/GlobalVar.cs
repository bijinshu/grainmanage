using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web
{
    public class GlobalVar
    {
        public const string CacheMinute = "CacheMinute";
        public const string CookieName = "GrainManage";
        public const string HeadLogName = "log-action";

        public const string Content = "c";
        public const string Sign = "s";

        public const int MaxLevel = 100;
        public const int AdminLevel = 90;

        public static string ContentRootPath { get; set; }

        public const int Role_User = 2;
        public const int Role_Shop = 3;
        public const int Role_Employee = 5;

        public const string JwtSecret = "abcd&*@#%^#IOPSDKF";
    }
}