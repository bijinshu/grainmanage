using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Message;
using GrainManage.Web.Common;
using GrainManage.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GrainManage.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private static readonly JsonSerializerSettings defaultSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
        public bool IsGetRequest { get { return Request.Method == "GET"; } }
        public bool IsSuperAdmin { get { return Level >= GlobalVar.MaxLevel; } }
        protected ActionResult JsonNet(object data, bool includeNotValid = false)
        {
            if (includeNotValid)
            {
                var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                return Json(data, settings);
            }
            return Json(data, defaultSettings);
        }
        protected IRepository<T> GetRepo<T>() where T : class, new()
        {
            return HttpContext.RequestServices.GetService(typeof(IRepository<T>)) as IRepository<T>;
        }
        protected T Resolve<T>() where T : class
        {
            return HttpContext.RequestServices.GetService(typeof(T)) as T;
        }
        protected void SetResponse(Expression<Func<StatusCode, int>> selector, object input, BaseOutput output)
        {
            var messageInfo = CacheMessage.Get(selector);
            output.code = messageInfo.Code;
            output.msg = messageInfo.Description;
        }
        protected void SetResponse(Expression<Func<StatusCode, int>> selector, BaseOutput output)
        {
            SetResponse(selector, null, output);
        }
        protected static T MapTo<T>(Object srcObj)
        {
            return AutoMapper.Mapper.Map<T>(srcObj);
        }
        protected static void Map<Source, Dest>(Source src, Dest dest)
        {
            AutoMapper.Mapper.Map(src, dest);
        }
        protected static T DynamicMap<T>(Object srcObj)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap(srcObj.GetType(), typeof(T)));
            var mapper = config.CreateMapper();
            return mapper.Map<T>(srcObj);
        }
        protected UserInfo CurrentUser { get { return Resolve<ICache>().Get<UserInfo>(CacheKey.GetUserKey(UserId)); } }
        protected int UserId { get { return CookieUtil.GetCookie<int>(Request.Cookies, GlobalVar.CookieName, GlobalVar.UserId); } }
        protected int Level { get { return int.Parse(CookieUtil.GetCookie(Request.Cookies, GlobalVar.CookieName, GlobalVar.Level)); } }
        protected string AuthToken { get { return CookieUtil.GetCookie(Request.Cookies, GlobalVar.CookieName, GlobalVar.AuthToken); } }
        protected void SetEmptyIfNull<T>(T obj)
        {
            var type = typeof(T);
            foreach (var item in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                if (item.PropertyType == typeof(string) && item.GetValue(obj) == null)
                {
                    item.SetValue(obj, string.Empty);
                }
            }
        }
    }
}
