using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace TradeTracker.Api.Services
{
    public interface ICurrentUserService
    {
        string AccessKey { get; }
        string UserId { get; }
    }

    public class CurrentUserService : ICurrentUserService
    {
        private Guid _accessKey = Guid.Empty;
        public string AccessKey { get => _accessKey.ToString(); }
        public string UserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Guid.TryParse(
                httpContextAccessor.HttpContext?.User?.FindFirstValue("AccessKey"), 
                out _accessKey);

            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
