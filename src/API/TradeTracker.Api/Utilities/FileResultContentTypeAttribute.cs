using System;

namespace TradeTracker.Api.Utilities
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

        public string ContentType { get; }
    }
}
