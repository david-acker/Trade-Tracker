using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Option", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseCustomExceptionHandler();
            app.UseCors("Open");
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
