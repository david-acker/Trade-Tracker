using System;

namespace TradeTracker.Application.Common.Exceptions
{
    public class ResourceStateConflictException : ApplicationException
    {
        public ResourceStateConflictException(string message): base(message)
        {
        }
    }
}
