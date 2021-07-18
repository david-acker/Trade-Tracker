using Microsoft.Net.Http.Headers;
using System;

namespace TradeTracker.Api.Services
{
    public interface IMediaTypeService
    {
        bool IsLinkedRepresentation(string acceptHeader);
    }

    public class MediaTypeService : IMediaTypeService
    {
        public MediaTypeService()
        {
        }

        public bool IsLinkedRepresentation(string acceptHeader)
        {
            if (MediaTypeHeaderValue.TryParse(acceptHeader, out var mediaType))
            {
                return mediaType.SubTypeWithoutSuffix
                    .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}
