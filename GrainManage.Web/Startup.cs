using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.RegisterServices;
using System.Configuration;

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
            IRegisterService register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal(false, null);

            //开始注册微信信息，必须！
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);
        }
    }
}
