using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web
{
    public class UrlVar
    {
        //Home
        [Common]
        public static string Home_Index { get { return GetUrl("/Home/Index"); } }
        [Common]
        public const string Home_MenuTree = "/Home/MenuTree";
        //Role
        public static string Role_Index { get { return GetUrl("/Role/Index"); } }
        public static string Role_New { get { return GetUrl("/Role/New"); } }
        public static string Role_Edit { get { return GetUrl("/Role/Edit"); } }
        public static string Role_Delete { get { return GetUrl("/Role/Delete"); } }
        [Common]
        public const string Role_GetRoleList = "/Role/GetRoleList";
        //User
        [Common]
        public static string User_SignIn { get { return GetUrl("/User/SignIn"); } }
        [Common]
        public static string User_Register { get { return GetUrl("/User/Register"); } }
        [Common]
        public static string User_ResetPassword { get { return GetUrl("/User/ResetPassword"); } }
        [Common]
        public static string User_SignOut { get { return GetUrl("/User/SignOut"); } }
        [Common]
        public static string User_ChangePassword { get { return GetUrl("/User/ChangePassword"); } }

        //Contact
        public static string Contact_Index { get { return GetUrl("/Contact/Index"); } }
        public static string Contact_New { get { return GetUrl("/Contact/New"); } }
        public static string Contact_Edit { get { return GetUrl("/Contact/Edit"); } }
        public static string Contact_Delete { get { return GetUrl("/Contact/Delete"); } }

        //Trade



        #region 工具方法
        public static bool Has(string url, IEnumerable<string> urlList)
        {
            if (CookieUtil.GetCookie<int>(GlobalVar.CookieName, GlobalVar.Level) < GlobalVar.MaxLevel)
            {
                return urlList.Any(a => string.Equals(a.Trim().Trim('/'), url.Trim().Trim('/'), StringComparison.CurrentCultureIgnoreCase));
            }
            return true;
        }
        /// <summary>
        /// 当应用部署为子网站时，可通过此种方法获取到包含子应用的相对地址
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string GetUrl(string relativeUrl)
        {
            if (enableUrl)
            {
                if (string.IsNullOrEmpty(relativeUrl))
                {
                    return "javascript:void(0)";
                }
                return string.Format("{0}/{1}", HttpContext.Current.Request.ApplicationPath.TrimEnd('/'), relativeUrl.Trim('/'));
            }
            return relativeUrl;
        }
        private static bool enableUrl = false;
        public static void EnableRawUrl()
        {
            enableUrl = true;
        }
        public static void DisableRawUrl()
        {
            enableUrl = false;
        }
        #endregion
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CommonAttribute : Attribute
    {

    }
}