using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using GrainManage.Core;
using Autofac.Integration.Mvc;
using GrainManage.Common;
using GrainManage.Web.Cache;
namespace GrainManage.Web
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<ContextFactory>().As<IContextFactory>().InstancePerRequest();
            builder.RegisterType<RedisCache>().As<ICache>().InstancePerRequest();
            var container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//设置MVC Controller IoC
        }
    }
}