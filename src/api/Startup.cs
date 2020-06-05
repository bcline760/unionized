using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Unionized.Service;

namespace Unionized.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            IsDevelopment = env.IsDevelopment();

            var appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);

            // In ASP.NET Core 3.0 env will be an IWebHostEnvironment , not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"{appDir}/unionized/appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public bool IsDevelopment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Don't have a reference to the DI framework...yet or I don't know how to get it...yet
            var config = Configuration.Get<UnionizedConfiguration>();
            var appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var certificatePath = string.Format(config.Certificate.CertificateLocation, $"{appDir}/unionized");

            //services.AddControllers()
            //    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddOptions();
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateTokenReplay = true,
                    IssuerSigningKey = new X509SecurityKey(new X509Certificate2(certificatePath, config.Certificate.Password)),
                    ValidateIssuer = !IsDevelopment,
                    ValidateAudience = !IsDevelopment
                };
            });
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            });
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var config = Configuration.Get<UnionizedConfiguration>();
            var appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);

            string path = string.Format(config.Certificate.CertificateLocation, $"{appDir}/unionized");
            config.Certificate.CertificateLocation = path;
            builder.RegisterInstance(config).SingleInstance();
            RegisterModules.Register(builder, config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If, for some reason, you need a reference to the built container, you
            // can use the convenience extension method GetAutofacRoot.
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (IsDevelopment)
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
