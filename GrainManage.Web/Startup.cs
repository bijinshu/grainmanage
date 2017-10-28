using GrainManage.Common;
using GrainManage.Core;
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

            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContextFactory, ContextFactory>();
            //var builder = new ContainerBuilder();
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            //builder.RegisterType<ContextFactory>().As<IContextFactory>();
            //builder.Populate(services);
            //return new AutofacServiceProvider(builder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
