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
        public const string UserId = "UserId";
        public const string UserName = "UserName";
        public const string AppId = "AppId";
        public const string AuthToken = "AuthToken";
        public const string ValidateCode = "ValidateCode";
        public const string Level = "Level";

        public const int MaxLevel = 100;
        public const int AdminLevel = 90;

        public static string ContentRootPath { get; set; }
    }
}