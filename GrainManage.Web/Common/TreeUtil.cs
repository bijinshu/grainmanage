using GrainManage.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Common
{
    public class TreeUtil
    {
        /// <summary>
        /// 根据授权id,填充授权url到列表中
        /// </summary>
        /// <param name="currentTreeList"></param>
        /// <param name="allValidIdList"></param>
        /// <param name="result"></param>
        public static void GetUrls(List<Tree> currentTreeList, string[] allValidIdList, List<string> result)
        {
            if (currentTreeList != null && currentTreeList.Any())
            {
                foreach (var item in currentTreeList)
                {
                    if (allValidIdList.Any(a => string.Equals(item.id, a, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (!result.Contains(item.url) && !string.IsNullOrEmpty(item.url))
                        {
                            result.Add(item.url);
                        }
                    }
                    GetUrls(item.children, allValidIdList, result);
                }
            }
        }
        /// <summary>
        /// 获取当前列表树及其子树的Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentTreeList"></param>
        /// <param name="result"></param>
        /// <param name="downWard"></param>
        public static void GetIds<T>(List<Tree> currentTreeList, List<T> result, Func<Tree, bool> condition = null)
        {
            if (currentTreeList != null && currentTreeList.Any())
            {
                foreach (var item in currentTreeList)
                {
                    if (condition == null || condition(item))
                    {
                        if (!result.Contains(item.id))
                        {
                            result.Add(item.id);
                        }
                    }
                    GetIds(item.children, result, condition);
                }
            }
        }

        /// <summary>
        /// 删除掉无效项
        /// </summary>
        /// <param name="currentTreeList"></param>
        /// <param name="allValidIdList"></param>
        public static void RemoveNotValid(List<Tree> currentTreeList, List<string> allValidIdList)
        {
            if (currentTreeList != null)
            {
                currentTreeList.RemoveAll(s => !allValidIdList.Contains(s.id));
                foreach (var menu in currentTreeList)
                {
                    RemoveNotValid(menu.children, allValidIdList);
                }
            }
        }
        /// <summary>
        /// 设置树形结构项的父id
        /// </summary>
        /// <param name="currentTreeList"></param>
        public static void SetParent(List<Tree> currentTreeList)
        {
            foreach (var item in currentTreeList)
            {
                item.expanded = true;
                if (item.children != null && item.children.Any())
                {
                    foreach (var child in item.children)
                    {
                        child.expanded = true;
                        child.parentId = item.id;
                    }
                    SetParent(item.children);
                }
            }
        }
        /// <summary>
        /// 将列表项组织为树形结构项
        /// </summary>
        /// <param name="topItemList"></param>
        /// <param name="allItemList"></param>
        public static void BuildTree(List<Tree> topItemList, List<Tree> allItemList)
        {
            if (topItemList != null && topItemList.Any())
            {
                foreach (var item in topItemList)
                {
                    if (item.children == null)
                    {
                        var children = allItemList.Where(f => f.parentId == item.id).ToList();
                        if (children.Any())
                        {
                            item.children = children;
                            BuildTree(item.children, allItemList);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 从树结构中找到子项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Tree GetChild(dynamic id, List<Tree> list)
        {
            Tree childTree = null;
            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    if (item.id == id)
                    {
                        childTree = item;
                        break;
                    }
                    else
                    {
                        childTree = GetChild(id, item.children);
                        if (childTree != null)
                        {
                            break;
                        }
                    }
                }
            }
            return childTree;
        }
    }
}