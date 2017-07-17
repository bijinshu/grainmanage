using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Models;
using GrainManage.Web;
using GrainManage.Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private static List<int> ignoredStatus = new List<int> { 1, 9 };
        public bool IsGetRequest { get { return Request.HttpMethod == "GET"; } }

        protected static NewtonsoftJsonResult JsonNet(object data)
        {
            return new NewtonsoftJsonResult { Data = data };
        }

        protected string GetSession(string key)
        {
            return Session[key] as string;
        }

        protected T GetSession<T>(string key)
        {
            T result = default(T);
            try
            {
                var obj = Session[key];
                if (obj != null)
                {
                    Type modelType = typeof(T);
                    if (modelType.IsValueType)
                    {
                        result = (T)Convert.ChangeType(obj, modelType);
                    }
                    else
                    {
                        result = (T)obj;
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
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
            var messageInfo = GrainManage.Message.CacheMessage.Get(selector);
            output.code = messageInfo.Code;
            output.msg = messageInfo.Description;
            if (!ignoredStatus.Contains(output.code))
            {
                //LogUtil.Write(2, LogLevel.Warn, input, output, null);
            }
        }

        protected static void SetResponse(object input, BaseOutput output, Exception e)
        {
            output.code = 0;
            output.msg = e.Message;
            //LogUtil.Write(2, LogLevel.Error, input, output, e);
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
        protected SafeInfo CurrentUser
        {
            get
            {
                var cache = Resolve<ICache>();
                return cache.Get<SafeInfo>(CacheKey.GetSafeInfoKey(UserName));
            }
        }
        protected string UserName { get { return CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.UserName); } }
        protected string AuthToken { get { return CookieUtil.GetCookie(GlobalVar.CookieName, GlobalVar.AuthToken); } }
    }
}
