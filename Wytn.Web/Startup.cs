using System.Reflection;

using Wytn.Sys.Model;
using Wytn.Sys.Repository;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Wytn.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // init RepoDb
            RepoDb.MySqlConnectorBootstrap.Initialize();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            
            services.AddSingleton<IConnectionFactory>(_ =>
                new ConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<PrincipalAccessor>();
            services.AddScoped<MailHelper>();
            services.AddScoped<ReportGenerator>();
            services.AddScoped<TokenProvider>();
            // configure DI 
            services.Scan(scan => scan
                .FromAssemblies(Assembly.Load("Wytn.Sys.Repository"))
                    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .FromAssemblies(Assembly.Load("Wytn.Sys.Service"))
                    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
