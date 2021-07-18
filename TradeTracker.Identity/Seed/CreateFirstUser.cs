using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Identity.Models;

namespace TradeTracker.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                AccessKey = Guid.Parse("322f44e6-bacd-42a4-9f8d-d0a8d36eb1cb"),
                FirstName = "FirstName",
                LastName = "LastName",
                UserName = "UserName",
                Email = "Email@Email.com",
                EmailConfirmed = true
            };

            var password = "Password1#";

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, password);

                await userManager.AddClaimAsync(applicationUser, 
                    new Claim("AccessKey", applicationUser.AccessKey.ToString()));
            }
        }
    }
}