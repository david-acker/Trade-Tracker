using System;
using Microsoft.Net.Http.Headers;

namespace TradeTracker.Api.Extensions
{
    public static class MediaTypeHeaderValueExtensions
    {
        public static bool IsRepresentationWithLinks(this MediaTypeHeaderValue mediaType)
        {
            return mediaType
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}