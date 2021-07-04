using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Employees.DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Employees
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    { 
                        Title = "Employees API",
                        Description = "Job Board Application",
                        Version = "v1"
                    });



                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                options.AddSecurityRequirement(securityRequirement);



                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = Configuration["JwtAuth:Issuer"],
                                ValidAudience = Configuration["JwtAuth:Issuer"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtAuth:Key"]))
                            };
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
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
            app.UseDeveloperExceptionPage();
            app.Use(async (context, next) =>
            {
                //context.Response.Headers.Add("X-Xss-Protection", "1");

                /*context.Response.Headers.Add(
                        "Content-Security-Policy",
                        "default-src https: 'unsafe-inline'; " +
                        "font-src *;" +
                        "img-src * data:;" +
                        "script-src https: 'unsafe-inline'; " +
                        "style-src https: 'unsafe-inline';" +
                        "frame-ancestors 'none'");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");*/
                //context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                /*context.Response.Headers.Add("Feature-Policy", "sync-xhr *;payment 'none'");
                context.Response.Headers.Add("X-Frame-Options", "DENY");*/
                context.Response.Headers.Add("Access-Control-Allow-Methods", "DELETE, POST, GET, OPTIONS");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
                context.Response.Headers.Remove("X-Powered-By");

                await next();
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees");
            });
        }
    }
}
