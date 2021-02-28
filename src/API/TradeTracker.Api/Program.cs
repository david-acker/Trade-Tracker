using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;
using TradeTracker.Identity;
using TradeTracker.Identity.Models;
using TradeTracker.Persistence;

namespace TradeTracker.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var persistenceContext = scope.ServiceProvider.GetRequiredService<TradeTrackerDbContext>();
                persistenceContext.Database.EnsureCreated();
            }

            using (var scope = host.Services.CreateScope())
            {
                var identityContext = scope.ServiceProvider.GetRequiredService<TradeTrackerIdentityDbContext>();
                identityContext.Database.EnsureCreated();
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    await Identity.Seed.UserCreator.SeedAsync(userManager);
                    Log.Information("Application Starting.");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred while starting the application.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
