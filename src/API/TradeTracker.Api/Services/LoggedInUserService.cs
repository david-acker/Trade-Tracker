using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TradeTracker.Application.Interfaces;

namespace TradeTracker.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            AccessKey = httpContextAccessor.HttpContext?.User?.FindFirstValue("AccessKey");
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string AccessKey { get; }
        public string UserId { get; }
    }
}
