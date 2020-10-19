using System;
using System.Security.Claims;
using System.IO;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Autofac;
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
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
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

            services.AddControllers();
            services.AddOptions();

            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            byte[] key = LoadEncryptionKey();

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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
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
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private byte[] LoadEncryptionKey()
        {
            byte[] encryptionKey = null;
            string path = $"{Environment.CurrentDirectory}/unionized.key";
            if (File.Exists("unionized.key"))
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    encryptionKey = new byte[fs.Length];
                    int bytesRead = fs.Read(encryptionKey);
                }
            }
            else
            {
                using (RSA rsa = RSA.Create())
                {
                    encryptionKey = rsa.ExportRSAPrivateKey();

                    // Write the key to disk for future use.
                    using (FileStream fs = File.OpenWrite(path))
                    {
                        fs.Write(encryptionKey);
                    }
                }
            }

            return encryptionKey;
        }
    }
}
