using GrainManage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web
{
    public class WebResolver : IResolver
    {
        public T Get<T>(Type serviceType = null) where T : class
        {
            if (serviceType != null)
            {
                return System.Web.Mvc.DependencyResolver.Current.GetService(serviceType) as T;
            }
            return System.Web.Mvc.DependencyResolver.Current.GetService<T>();
        }
    }
}