using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TradeTracker.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
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

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/TradeTrackerOpenAPISpecification/swagger.json",
                    "TradeTracker API");
                
                setupAction.RoutePrefix = "swagger";
            });
        }
    }
}