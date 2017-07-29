using GrainManage.Dal;
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
        public static List<Menu> GetMenus()
        {
            var menu = string.Empty;
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/menu.json"))) { menu = reader.ReadToEnd(); }
            var menuList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menu>>(menu);
            return menuList;
        }

        public static List<string> GetAuths(params int[] roleIds)
        {
            var list = new List<string>();
            var db = new GrainManageDB();
            var auths = db.Select<string>(string.Format("select Auths from rm_role where Id in({0})", string.Join(",", roleIds)));
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

        public static void RemoveNotValid(List<Menu> menuList, IEnumerable<string> authList)
        {
            if (menuList != null)
            {
                menuList.RemoveAll(s => !authList.Contains(s.id));
                foreach (var menu in menuList)
                {
                    RemoveNotValid(menu.children, authList);
                }
            }
        }

        /// <summary>
        /// 根据权限列表标记哪些菜单可用及补充父
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="auths"></param>
        public static void MarkMenus(List<Menu> menus, List<string> auths)
        {
            foreach (var item in menus)
            {
                if (auths != null && auths.Any())
                {
                    item.selected = auths.Any(s => s == item.id);
                }
                if (item.children != null && item.children.Any())
                {
                    foreach (var child in item.children)
                    {
                        child.parent = item.id;
                    }
                    MarkMenus(item.children, auths);
                }
            }
        }
    }
}