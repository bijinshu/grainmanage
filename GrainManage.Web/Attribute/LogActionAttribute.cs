﻿using DataBase.GrainManage.Models.Log;
using GrainManage.Web.Cache;
using GrainManage.Web.Common;
using GrainManage.Web.Jobs;
using GrainManage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Web;

namespace GrainManage.Web
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (UrlCache.IsUrlExisted(url))
            {
                var headers = filterContext.HttpContext.Request.Headers;
                ActionLog model = new ActionLog();
                model.Path = HttpUtility.UrlDecode(filterContext.HttpContext.Request.Path.Value, Encoding.UTF8);
                model.ClientIP = HttpUtil.GetClientIP(filterContext.HttpContext.Request);
                model.Method = filterContext.HttpContext.Request.Method;
                model.Para = HttpUtil.GetInputPara(filterContext.HttpContext.Request);
                model.StartTime = DateTime.Now;
                var currentUser = UserUtil.GetFromCookie(filterContext.HttpContext.Request.Cookies);
                if (currentUser != null)
                {
                    model.UserId = currentUser.UserId;
                    model.UserName = currentUser.UserName;
                    model.Level = currentUser.Level;
                }
                else
                {
                    model.UserName = string.Empty;
                }
                var guid = Guid.NewGuid().ToString("N");
                LogCache.Add(guid, model);
                headers.Add(GlobalVar.HeadLogName, guid);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var url = string.Format("/{0}/{1}", values["controller"] as string, values["action"] as string);
            if (UrlCache.IsUrlExisted(url))
            {
                var guid = filterContext.HttpContext.Request.Headers[GlobalVar.HeadLogName].First();
                var now = DateTime.Now;
                var msg = string.Empty;
                JsonResult result = null;
                if (filterContext.HttpContext.Request.Method == "POST" && (result = filterContext.Result as JsonResult) != null)
                {
                    var baseOutput = result.Value as BaseOutput;
                    if (baseOutput != null)
                    {
                        msg = baseOutput.msg;
                    }
                }
                LogCache.Set(guid, msg);
            }
        }
    }
}