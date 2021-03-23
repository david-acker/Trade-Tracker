using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using TradeTracker.Api.Extensions;
using TradeTracker.Api.Extensions.Setup;
using TradeTracker.Api.Middleware;
using TradeTracker.Api.Services;
using TradeTracker.Application;
using TradeTracker.Application.Interfaces;
using TradeTracker.Identity;
using TradeTracker.Infrastructure;
using TradeTracker.Persistence;

namespace TradeTracker.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);
            services.AddIdentityServices(Configuration);

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
        
            services.AddControllers(setupAction => setupAction.ConfigureStatusCodes())
                .AddNewtonsoftJsonSerializationSettings();

            services.SetupNewtonsoftJsonFormatting();

            services.AddRateLimiter(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("Option", builder => 
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddSwagger();

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "../../UI/TradeTrackerUI/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault occurred. Try again later.");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.ConfigureSwagger();

            app.UseIpRateLimiting();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCustomExceptionHandler();
            app.UseCors("Open");
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa => 
            {
                spa.Options.SourcePath = "../../UI/TradeTrackerUI";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
