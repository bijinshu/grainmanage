using GrainManage.Dal;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace GrainManage.Web.Services
{
    public class CommonService
    {
        /// <summary>
        /// 获取用户主菜单
        /// </summary>
        /// <returns></returns>
        public static List<Tree> GetMenus()
        {
            var menu = string.Empty;
            using (var reader = new StreamReader(HttpUtil.GetServerPath("menu.json"))) { menu = reader.ReadToEnd(); }
            var menuList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tree>>(menu);
            return menuList;
        }
        /// <summary>
        /// 获取授权菜单id
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static List<string> GetAuths(params int[] roleIds)
        {
            var list = new List<string>();
            var db = new GrainManageDB();
            var auths = db.Select<string>(string.Format("select Auths from rm_role where Id in({0})", string.Join(",", roleIds))).Where(f => !string.IsNullOrEmpty(f));
            if (auths != null && auths.Any())
            {
                foreach (var auth in auths)
                {
                    foreach (var item in auth.Split(','))
                    {
                        if (!list.Any(s => string.Equals(s, item, StringComparison.CurrentCultureIgnoreCase)))
                        {
                            list.Add(item);
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 获取授权url
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static List<string> GetUrls(params int[] roleIds)
        {
            var list = new List<string>();
            var db = new GrainManageDB();
            var auths = db.Select<string>(string.Format("select Auths from rm_role where Id in({0})", string.Join(",", roleIds))).Where(f => !string.IsNullOrEmpty(f));
            if (auths != null && auths.Any())
            {
                var menus = GetMenus();
                foreach (var item in auths)
                {
                    TreeUtil.GetUrls(menus, item.Split(','), list);
                }
            }
            return list;
        }
    }
}