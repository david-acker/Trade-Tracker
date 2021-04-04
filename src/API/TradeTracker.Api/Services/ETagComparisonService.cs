using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using TradeTracker.Application.Common.Interfaces;

namespace TradeTracker.Api.Services
{
    public class ETagService : IETagService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ETagService> _logger;

        public ETagService(
            IHttpContextAccessor httpContextAccessor,
            ILogger<ETagService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public string GetETagFromHeader()
        {
            return _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.IfMatch];
        }
    }
}
