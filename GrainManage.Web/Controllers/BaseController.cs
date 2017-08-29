using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Models;
using GrainManage.Web;
using GrainManage.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GrainManage.Message;

namespace GrainManage.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public bool IsGetRequest { get { return Request.HttpMethod == "GET"; } }
        public bool IsSuperAdmin { get { return Level >= GlobalVar.MaxLevel; } }
        protected static NewtonsoftJsonResult JsonNet(object data, bool includeNotValid = false)
        {
            return new NewtonsoftJsonResult { Data = data, IncludeNotValid = includeNotValid };
        }

        protected IRepository<T> GetRepo<T>() where T : class, new()
        {
            return DependencyResolver.Current.GetService<IRepository<T>>();
        }
        protected T Resolve<T>()
        {
            return DependencyResolver.Current.GetService<T>();
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
        protected int UserId { get { return CookieUtil.GetCookie<int>(GlobalVar.CookieName, GlobalVar.UserId); } }
        protected int Level { get { return int.Parse(CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.Level)); } }
        protected string AuthToken { get { return CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken); } }
    }
}
