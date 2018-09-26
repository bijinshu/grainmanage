using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Senparc.CO2NET;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.RegisterServices;
using System.Collections.Generic;

namespace GrainManage.Web
{
    public class Startup
    {
        //public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            AppConfig.Handler = (key) => { return configuration[key]; };
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new CheckLoginAttribute());
                options.Filters.Add(new LogActionAttribute());
                options.Filters.Add(new LogExceptionAttribute());
            });
            services.AddSenparcGlobalServices(Configuration);//Senparc.CO2NET 全局注册
            services.AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContextFactory, ContextFactory>();
            services.AddScoped<ICache, RedisCache>();

            MapperConfig.Initialize();

            LogScheler.Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            GlobalVar.ContentRootPath = env.ContentRootPath;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Weixin}/{action=Index}/{id?}");
            });
            // 启动 CO2NET 全局注册，必须！
            //配置全局使用Redis缓存（按需，独立）
            var register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal(false, null);
            //var register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal(false, () => GetExCacheStrategies(senparcSetting.Value));
            var redisConfigurationStr = senparcSetting.Value.Cache_Redis_Configuration;
            var useRedis = !string.IsNullOrEmpty(redisConfigurationStr) && redisConfigurationStr != "Redis配置";

            #region 缓存配置（按需）
            //当同一个分布式缓存同时服务于多个网站（应用程序池）时，可以使用命名空间将其隔离（非必须）
            register.ChangeDefaultCacheNamespace("DefaultCO2NETCache");
            if (useRedis)
            {
                //设置Redis链接信息，并在全局立即启用Redis缓存。
                //Senparc.CO2NET.Cache.Redis.Register.SetConfigurationOption(redisConfigurationStr);
            }
            #endregion

            #region 微信相关配置
            //if (useRedis)
            //{
            //    app.UseSenparcWeixinCacheRedis();
            //}
            //开始注册微信信息，必须！
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);

            #endregion
            #region 微信公众号注册
            if (!AccessTokenContainer.CheckRegistered(Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppId))//检查是否已经注册
            {
                AccessTokenContainer.Register(Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppId, Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppSecret);//如果没有注册则进行注册
            }
            #endregion
        }

        /// <summary>
        /// 获取扩展缓存策略
        /// </summary>
        /// <returns></returns>
        //private IList<IDomainExtensionCacheStrategy> GetExCacheStrategies(SenparcSetting senparcSetting)
        //{
        //    var exContainerCacheStrategies = new List<IDomainExtensionCacheStrategy>();
        //    senparcSetting = senparcSetting ?? new SenparcSetting();
        //    //判断Redis是否可用
        //    var redisConfiguration = senparcSetting.Cache_Redis_Configuration;
        //    if (!string.IsNullOrEmpty(redisConfiguration) && redisConfiguration != "Redis配置")
        //    {
        //        exContainerCacheStrategies.Add(RedisContainerCacheStrategy.Instance);
        //    }
        //    return exContainerCacheStrategies;
        //}
    }
}