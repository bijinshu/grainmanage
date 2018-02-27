﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainManage.Web
{
    public class UrlVar
    {
        //Home
        [Common]
        public static string Home_Index { get { return GetUrl("/Home/Index"); } }
        [Common]
        public const string Home_MenuTree = "/Home/MenuTree";
        [Common]
        public const string Home_PerfectComp = "/Home/PerfectComp";
        //Role
        public static string Role_Index { get { return GetUrl("/Role/Index"); } }
        public static string Role_New { get { return GetUrl("/Role/New"); } }
        public static string Role_Edit { get { return GetUrl("/Role/Edit"); } }
        public static string Role_Delete { get { return GetUrl("/Role/Delete"); } }
        [Common]
        public const string Role_GetRoleList = "/Role/GetRoleList";
        //User
        public static string User_Index { get { return GetUrl("/User/Index"); } }
        public static string User_New { get { return GetUrl("/User/New"); } }
        public static string User_Edit { get { return GetUrl("/User/Edit"); } }
        public static string User_Delete { get { return GetUrl("/User/Delete"); } }
        public static string User_SignIn { get { return GetUrl("/User/SignIn"); } }
        public static string User_Register { get { return GetUrl("/User/Register"); } }
        public static string User_ResetPwd { get { return GetUrl("/User/ResetPwd"); } }
        [Common]
        public static string User_SignOut { get { return GetUrl("/User/SignOut"); } }
        [Common]
        public static string User_ChangePwd { get { return GetUrl("/User/ChangePwd"); } }
        [Common]
        public static string User_Info { get { return GetUrl("/User/Info"); } }

        //Employee
        public static string Employee_Index { get { return GetUrl("/Employee/Index"); } }
        public static string Employee_New { get { return GetUrl("/Employee/New"); } }
        public static string Employee_Edit { get { return GetUrl("/Employee/Edit"); } }
        public static string Employee_Delete { get { return GetUrl("/Employee/Delete"); } }

        //Contact
        public static string Contact_Index { get { return GetUrl("/Contact/Index"); } }
        public static string Contact_New { get { return GetUrl("/Contact/New"); } }
        public static string Contact_Edit { get { return GetUrl("/Contact/Edit"); } }
        public static string Contact_Delete { get { return GetUrl("/Contact/Delete"); } }

        //Trade

        //Log
        public static string Log_ExceptionList { get { return GetUrl("/Log/ExceptionList"); } }
        public static string Log_ActionList { get { return GetUrl("/Log/ActionList"); } }
        public static string Log_JobList { get { return GetUrl("/Log/JobList"); } }
        public static string Log_LoginList { get { return GetUrl("/Log/LoginList"); } }
        public static string Log_DeleteException { get { return GetUrl("/Log/DeleteException"); } }


        //Product
        public static string Product_List { get { return GetUrl("/Product/List"); } }
        #region 工具方法
        public static bool Has(int currentLevel, string url, IEnumerable<string> urlList)
        {
            if (currentLevel < GlobalVar.MaxLevel)
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
            if (string.IsNullOrEmpty(relativeUrl))
            {
                return "javascript:void(0)";
            }
            return HttpUtil.GetServerPath(relativeUrl);
        }
        #endregion
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CommonAttribute : Attribute
    {

    }
}