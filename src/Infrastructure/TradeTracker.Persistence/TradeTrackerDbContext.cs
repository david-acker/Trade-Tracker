using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Interfaces;
using TradeTracker.Persistence.Seed.Transactions;

namespace TradeTracker.Persistence
{
    public class TradeTrackerDbContext : DbContext, ITradeTrackerDbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IDomainEventService _domainEventService;

        public TradeTrackerDbContext(DbContextOptions<TradeTrackerDbContext> options)
           : base(options)
        {
        }

        public TradeTrackerDbContext(
            DbContextOptions<TradeTrackerDbContext> options, 
            ILoggedInUserService loggedInUserService,
            IDomainEventService domainEventService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
            _domainEventService = domainEventService;
        }

        public DbSet<Transaction> Transactions { get; set; }
        // public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TradeTrackerDbContext).Assembly);

            // var equityTransactions = TransactionSeeder.GenerateEquityTransactions(
            //     accessKey: Guid.Empty,
            //     transactionCount: 2500);

            // modelBuilder.Entity<Transaction>().HasData(equityTransactions);

            modelBuilder.Entity<Position>().Property(p => p.Quantity).HasField("_quantity");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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

            var events = ExtractEvents();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);

            return result;
        }

        private IEnumerable<DomainEvent> ExtractEvents()
        {
            return ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToList();
        }

        private async Task DispatchEvents(IEnumerable<DomainEvent> events)
        {
            while (true)
            {
                var domainEvent = events
                    .Where(e => !e.IsPublished)
                    .FirstOrDefault();

                if (domainEvent == null)
                {
                    break;
                }

                domainEvent.IsPublished = true;
                await _domainEventService.Publish(domainEvent);
            }
        }
    }
}
