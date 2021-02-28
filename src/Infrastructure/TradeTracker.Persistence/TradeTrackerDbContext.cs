using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;
using TradeTracker.Persistence.Seed.Transactions;

namespace TradeTracker.Persistence
{
    public class TradeTrackerDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public TradeTrackerDbContext(DbContextOptions<TradeTrackerDbContext> options)
           : base(options)
        {
        }

        public TradeTrackerDbContext(DbContextOptions<TradeTrackerDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TradeTrackerDbContext).Assembly);

            var equityTransactions = TransactionSeeder.GenerateEquityTransactions(
                accessTag: "testUserName",
                transactionCount: 1000);

            modelBuilder.Entity<Transaction>().HasData(equityTransactions);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
