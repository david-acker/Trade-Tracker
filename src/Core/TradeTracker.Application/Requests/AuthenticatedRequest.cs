using System;

namespace TradeTracker.Application.Requests
{
    public class AuthenticatedRequest
    {
        protected Guid _accessKey = Guid.Empty;
        public Guid AccessKey { get => _accessKey; }

        public void Authenticate(Guid accessKey)
        {
            _accessKey = accessKey;
        }
    }
}