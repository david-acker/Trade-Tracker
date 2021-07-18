using System;

namespace TradeTracker.Api.DTOs.Identity.Authentication
{
    public class AuthenticationResponseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
