using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace TradeTracker.Api.Services
{
    public interface ICurrentUserService
    {
        string AccessKey { get; set; } 
    }

    public class CurrentUserService : ICurrentUserService
    {
        public string AccessKey { get ; set; } = Guid.Empty.ToString();

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            AccessKey = httpContextAccessor.HttpContext?.User?.FindFirstValue("AccessKey");
        }
    }
}
