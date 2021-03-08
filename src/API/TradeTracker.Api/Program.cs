using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;
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

            await ConfirmRequiredDatabases(host);
            await ForceRefreshUserPositions(host);
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private async static Task ConfirmRequiredDatabases(IHost host)
        {
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
        }

        private async static Task ForceRefreshUserPositions(IHost host)
        {
            IEnumerable<Guid> accessKeys;

            using (var scope = host.Services.CreateScope())
            {
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

                var identityContext = scope.ServiceProvider.GetRequiredService<TradeTrackerIdentityDbContext>();
                
                accessKeys = identityContext.Users
                    .Select(i => i.AccessKey)
                    .ToList();

                Log.Information($"ForceRefreshUserPositions: Identified {accessKeys.Count()} AccessKeys for users.");
            }

            using (var scope = host.Services.CreateScope())
            {
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

                var transactionRepository = scope.ServiceProvider.GetRequiredService<ITransactionRepository>();

                var positionService = scope.ServiceProvider.GetRequiredService<IPositionService>();

                IEnumerable<string> symbolsForUser;

                foreach (var key in accessKeys)
                {
                    Log.Information($"ForceRefreshUserPositions: Recalculating for AccessKey {key}");

                    symbolsForUser = transactionRepository.GetSetOfSymbolsForAllTransactionsByUser(key);

                    foreach (var symbol in symbolsForUser)
                    {
                        await positionService.RecalculateForSymbol(key, symbol);
                    }

                    Log.Information($"ForceRefreshUserPositions: Recalculated positions for {symbolsForUser.Count()} symbols.");
                }

                Log.Information($"ForceRefreshUserPositions: Completed recalculation for all users.");
            }
        }

    }
}
