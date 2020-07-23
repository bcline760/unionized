using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Autofac;
using Unionized.Api.Controllers;
using Autofac.Core;
using Unionized.Service;

namespace Unionized.Api
{
    public class Startup
    {
        public bool IsDevelopment { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            IsDevelopment = env.IsDevelopment();

            IConfigurationBuilder builder = null;

            if (IsDevelopment)
            {
                builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            }
            else
            {
                builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            }

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Don't have a reference to the DI framework...yet or I don't know how to get it...yet
            var config = Configuration.Get<UnionizedConfiguration>();
            var appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var certificatePath = string.Format(config.Certificate.CertificateLocation, $"{appDir}/unionized");
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

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var config = Configuration.Get<UnionizedConfiguration>();

            string path = string.Format(config.Certificate.CertificateLocation, ".");
            config.Certificate.CertificateLocation = path;

            builder.RegisterInstance(config).SingleInstance();
            RegisterModules.Register(builder, config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
