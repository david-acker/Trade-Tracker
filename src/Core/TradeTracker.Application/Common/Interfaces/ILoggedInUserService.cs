using System;

namespace TradeTracker.Application.Interfaces
{
    public interface ILoggedInUserService
    {
        Guid AccessKey { get; }
        string UserId { get; }

        bool IsLoggedIn();
    }
}
