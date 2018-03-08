using System;
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
        public static string Home_MenuTree { get { return GetUrl("/Home/MenuTree"); } }
        //Company
        [Common]
        public static string Company_New { get { return GetUrl("/Company/New"); } }
        public static string Company_Edit { get { return GetUrl("/Company/Edit"); } }
        [Common]
        public static string Company_GetList { get { return GetUrl("/Company/GetList"); } }
        [Common]
        public static string Company_DeleteFile { get { return GetUrl("/Company/DeleteFile"); } }
        //Role
        public static string Role_Index { get { return GetUrl("/Role/Index"); } }
        public static string Role_New { get { return GetUrl("/Role/New"); } }
        public static string Role_Edit { get { return GetUrl("/Role/Edit"); } }
        public static string Role_Delete { get { return GetUrl("/Role/Delete"); } }
        [Common]
        public static string Role_GetRoleList { get { return GetUrl("/Role/GetRoleList"); } }
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
        [Common]
        public static string Contact_GetList { get { return GetUrl("/Contact/GetList"); } }

        //Trade
        public static string Trade_Index { get { return GetUrl("/Trade/Index"); } }
        public static string Trade_New { get { return GetUrl("/Trade/New"); } }
        public static string Trade_Edit { get { return GetUrl("/Trade/Edit"); } }
        public static string Trade_Delete { get { return GetUrl("/Trade/Delete"); } }
        public static string Trade_GetByContactId { get { return GetUrl("/Trade/GetByContactId"); } }

        //Log
        public static string Log_ExceptionList { get { return GetUrl("/Log/ExceptionList"); } }
        public static string Log_ActionList { get { return GetUrl("/Log/ActionList"); } }
        public static string Log_JobList { get { return GetUrl("/Log/JobList"); } }
        public static string Log_LoginList { get { return GetUrl("/Log/LoginList"); } }
        public static string Log_DeleteException { get { return GetUrl("/Log/DeleteException"); } }


        //Product
        [Common]
        public static string Product_List { get { return GetUrl("/Product/List"); } }
        public static string Product_Index { get { return GetUrl("/Product/Index"); } }
        public static string Product_New { get { return GetUrl("/Product/New"); } }
        public static string Product_Edit { get { return GetUrl("/Product/Edit"); } }
        public static string Product_Delete { get { return GetUrl("/Product/Delete"); } }
        [Common]
        public static string Product_Copy { get { return GetUrl("/Product/Copy"); } }
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