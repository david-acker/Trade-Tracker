using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using TradeTracker.Application.Interfaces;

namespace TradeTracker.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private Guid _accessKey = Guid.Empty;
        public Guid AccessKey { get => _accessKey; }
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("AccessKey"), out _accessKey);
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsLoggedIn()
        {
            return AccessKey != Guid.Empty;
        }
    }
}
