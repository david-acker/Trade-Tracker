using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeTracker.Identity.Models;

namespace TradeTracker.Identity
{
    public class TradeTrackerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TradeTrackerIdentityDbContext(DbContextOptions<TradeTrackerIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
