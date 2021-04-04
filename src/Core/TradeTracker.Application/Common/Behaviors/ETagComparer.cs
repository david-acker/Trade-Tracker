using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Common.Behaviors
{
    public static class ETagComparer
    {
        public static bool IsConflict(object resource, string providedETag)
        {
            string resourceETag = EntityTagHelper.Generate(resource);

            return !resourceETag.Equals(providedETag);
        }
    }
}