using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Identity;
using TradeTracker.Identity.Models;

namespace TradeTracker.Api.Extensions
{
    public static class IHostExtensions
    {
        public static IHost ConfirmDatabase<TDbContext>(this IHost host) 
            where TDbContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var context = services.GetRequiredService<TDbContext>();

                try
                {
                    context.Database.EnsureCreated();

                    Log.Information($"Confirmed the database for {typeof(TDbContext)}");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, $"An error occured while confirming the database for {typeof(TDbContext)}");
                }
            }

            return host;
        }

        public static async Task<IHost> SeedIdentityDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var identityContext = services.GetRequiredService<TradeTrackerIdentityDbContext>();

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    await Identity.Seed.UserCreator.SeedAsync(userManager);
                    Log.Information($"Seeded {typeof(ApplicationUser)} in {typeof(TradeTrackerIdentityDbContext)}");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, $"An error occured while seeding {typeof(ApplicationUser)} in {typeof(TradeTrackerIdentityDbContext)}");
                }
            }

            return host;
        }

        public static async Task<IHost> ForceRefreshOfPositions(this IHost host)
        {
            List<Guid> accessKeys = new List<Guid>();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var identityContext = services.GetRequiredService<TradeTrackerIdentityDbContext>();

                var accessKeysFound = await identityContext.Users
                    .Select(i => i.AccessKey)
                    .ToListAsync();

                accessKeys.AddRange(accessKeysFound);

                Log.Information($"Found {accessKeys.Count()} AccessKeys for users");                                
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                var transactionRepository = services.GetRequiredService<ITransactionRepository>();
                var positionService = services.GetRequiredService<IPositionService>();

                HashSet<string> symbolsForUser;

                foreach  (var key in accessKeys)
                {
                    Log.Information($"Recalculating positions for user with AccessKey {key}");

                    symbolsForUser = transactionRepository.GetSetOfSymbolsForAllTransactionsByUser(key);

                    foreach (var symbol in symbolsForUser)
                    {
                        await positionService.RecalculateForSymbol(symbol, key);
                    }

                    Log.Information($"Recalculated positions for {symbolsForUser.Count()} symbols for user with AccessKey {key}");
                }

                Log.Information($"Completed recalculation for {accessKeys.Count()} users");
            }

            return host;
        }
    }
}