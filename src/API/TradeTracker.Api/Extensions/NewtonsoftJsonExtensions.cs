using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace TradeTracker.Api.Extensions
{
    public static class NewtonsoftJsonExtensions
    {
        public static IMvcBuilder AddNewtonsoftJsonSerializationSettings(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(setupAction => 
            {
                setupAction.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                setupAction.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            return builder;
        }
        public static IServiceCollection SetupNewtonsoftJsonFormatting(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                var newtonsoftJsonOutputFormatter = options.OutputFormatters
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

            return services;
        }
    }
}