﻿using System;

namespace TradeTracker.Identity.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
