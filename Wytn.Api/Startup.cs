using System.IO;
using System.Reflection;
using System.Text;

using Wytn.Api.Middleware;
using Wytn.Sys.Model;
using Wytn.Sys.Repository;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service;
using Wytn.Sys.Service.Interface;
using Wytn.Util;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Serilog;

namespace Wytn.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // init RepoDb
            RepoDb.MySqlConnectorBootstrap.Initialize();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddControllers()
                .AddApplicationPart(Assembly.Load("Wytn.Sys.Controller"));
            // AutoMapper
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            // Swagger
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            // Cache
            services.AddMemoryCache();

            services
                // 檢查 HTTP Header 的 Authorization 是否有 JWT Bearer Token
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // 設定 JWT Bearer Token 的檢查選項
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Issuer"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SignKey"]))
                    };
                });

            // configure strongly typed settings object
            services.AddSingleton<IConnectionFactory>(_ =>
                new ConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<TokenProvider>();
            services.AddScoped<PrincipalAccessor>();
            services.AddScoped<MailHelper>();
            services.AddScoped<ReportGenerator>();

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

            string[] cors = Configuration["App:Cors"].Split(",");
            // set Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(cors);
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Contect path
            //app.UsePathBase(new PathString("/api"));

            // ExceptionHandle
            app.UseExceptionHandleMiddleware();

            // Serilog
            app.UseSerilogRequestLogging();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            // Routing
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
