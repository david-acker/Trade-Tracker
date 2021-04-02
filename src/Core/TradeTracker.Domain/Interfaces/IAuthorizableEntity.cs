using System;

namespace TradeTracker.Domain.Interfaces
{
    public interface IAuthorizableEntity
    {
        Guid AccessKey { get; set; }
    }
}