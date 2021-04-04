using System;

namespace TradeTracker.Application.Common.Exceptions
{
    public class UnauthorizedRequestException : ApplicationException
    {
        public UnauthorizedRequestException(string message) : base(message)
        {
        }
    }
}