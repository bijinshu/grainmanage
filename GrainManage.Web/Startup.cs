using GrainManage.Common;
using GrainManage.Core;
using GrainManage.Web.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrainManage.Web
{
    public class Startup
    {
        //public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppConfig.Handler = (key) => { return Configuration[key]; };

            services.AddMvc(options =>
            {
                options.Filters.Add(new CheckLoginAttribute());
                options.Filters.Add(new LogActionAttribute());
                options.Filters.Add(new LogExceptionAttribute());
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContextFactory, ContextFactory>();
            services.AddScoped<ICache, RedisCache>();

            MapperConfig.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            GlobalVar.ContentRootPath = env.ContentRootPath;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
