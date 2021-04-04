using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeTracker.Application.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base(CreateMessageForSingle(name, key))
        {
        }

        public NotFoundException(string name, IEnumerable<object> keys)
            : base(CreateMessageForMultiple(name, keys))
        {
        }

        private static string CreateMessageForSingle(string name, object key)
        {
            return $"{name} ({key}) was not found.";
        }

        private static string CreateMessageForMultiple(string name, IEnumerable<object> keys)
        {
            if (keys.Count() == 1)
            {
                return CreateMessageForSingle(name, keys.Single());
            }
            else
            {
                var keysAsString = String.Join(", ", keys);

                return $"The following {name}s were not found: ({keysAsString}).";
            }
        }
    }
}
