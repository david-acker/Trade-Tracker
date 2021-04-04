using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TradeTracker.Application.Common.Interfaces;

namespace TradeTracker.Api.Services
{
    public class EntityTagService : IEntityTagService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<EntityTagService> _logger;

        public EntityTagService(
            IHttpContextAccessor httpContextAccessor,
            ILogger<EntityTagService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public string GetEntityTagFromHeader()
        {
            return _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.IfMatch];
        }
    }
}
