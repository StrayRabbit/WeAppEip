using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WeAppEip.Infrastructure.Data;
using WeAppEip.Web.Services;
using WeAppEip.Web.ViewModels.Configuration;
using Web.Interfaces;
using Web.Services;

namespace Web
{
    public class Startup
    {
        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IBannerViewModelService, BannerViewModelService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsViewModelService, NewsViewModelService>();
            services.AddScoped<IModuleRepository, ModuleReponsitory>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IModuleViewModelService, ModuleViewModelService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerViewModelService, CustomerViewModelService>();

            services.Configure<ConfigurationFile>(Configuration.GetSection("ConfigurationFile"));

            services.AddDbContext<EipContext>(options => options.UseMySQL(Configuration.GetConnectionString("EipConnection")));


            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                //配置大小写问题，默认是首字母小写
                //option.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

                //配置序列化时时间格式为yyyy-MM-dd HH:mm:ss
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseSession();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                    name: "areas",
                    areaName: "System",
                    template: "System/{controller=Account}/{action=Login}"
                );
            });
        }
    }
}
