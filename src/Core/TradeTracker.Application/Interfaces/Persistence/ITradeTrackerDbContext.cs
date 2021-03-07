using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface ITradeTrackerDbContext
    {
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}