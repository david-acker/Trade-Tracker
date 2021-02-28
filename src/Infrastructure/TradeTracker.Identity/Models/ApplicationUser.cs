using Microsoft.AspNetCore.Identity;

namespace TradeTracker.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        // public Guid AccessTag { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public bool IsActive { get; set; } = true;
    }
}
