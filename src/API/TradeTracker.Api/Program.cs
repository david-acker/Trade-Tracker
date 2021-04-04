using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using TradeTracker.Api.Extensions;
using TradeTracker.Identity;
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
            
            var host = CreateHostBuilder(args).Build()
                .ConfirmDatabase<TradeTrackerDbContext>()
                .ConfirmDatabase<TradeTrackerIdentityDbContext>();
            
            host = await host.SeedIdentityDatabase();
            host = await host.ForceRefreshOfPositions();
                
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
