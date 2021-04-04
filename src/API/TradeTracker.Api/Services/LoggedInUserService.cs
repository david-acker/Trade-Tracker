using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using TradeTracker.Application.Interfaces;

namespace TradeTracker.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private string _accessKey;
        public Guid AccessKey { get => Guid.Parse(_accessKey); }
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _accessKey = httpContextAccessor.HttpContext?.User?.FindFirstValue("AccessKey");
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
