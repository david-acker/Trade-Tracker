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
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
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
        
            services
                .AddControllers(setupAction =>
                {
                    setupAction.ReturnHttpNotAcceptable = true;

                    setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                    setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                    setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status429TooManyRequests));
                    setupAction.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                    setupAction.Filters.Add(
                        new ProducesDefaultResponseTypeAttribute());
                })
                .AddNewtonsoftJson(setupAction => 
                {
                    setupAction.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();

                    setupAction.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(
                Configuration.GetSection("IpRateLimiting"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy("Option", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters
                    .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.trade.hateoas+json");

                    if (newtonsoftJsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        newtonsoftJsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }

                    if (newtonsoftJsonOutputFormatter.SupportedMediaTypes.Contains("text/plain"))
                    {
                        newtonsoftJsonOutputFormatter.SupportedMediaTypes.Remove("text/plain");
                    }
                }
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "TradeTrackerOpenAPISpecification", 
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "TradeTracker API",
                        Version = "1",
                        Description = "API for accessing and managing transactions and positions with TradeTracker.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "davidacker3@gmail.com",
                            Name = "David Acker",
                            Url = new Uri("https://www.linkedin.com/in/daviddacker/")
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                var xmlCommmentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommmentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
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

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/TradeTrackerOpenAPISpecification/swagger.json",
                    "TradeTracker API");
                
                setupAction.RoutePrefix = "";
            });

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
        }
    }
}
