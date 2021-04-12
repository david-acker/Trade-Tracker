using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TradeTracker.Api.Extensions.Startup
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc(
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

                options.IncludeXmlComments(xmlCommentsFullPath, includeControllerXmlComments: true);
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/swagger/TradeTrackerOpenAPISpecification/swagger.json",
                    "TradeTracker API");
                
                options.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}