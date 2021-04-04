using System;

namespace TradeTracker.Application.Common.Exceptions
{
    public class ResourceStateConflictException : ApplicationException
    {
        public ResourceStateConflictException(string message): base(message)
        {
        }

        public ResourceStateConflictException(string name, object key) : 
            base(CreateMessage(name, key))
        {
        }

        private static string CreateMessage(string name, object key)
        {
            return $"The representation of the {name} ({key}) was changed.";
        }
    }
}
