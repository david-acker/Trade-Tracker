namespace TradeTracker.Application.Common.Behaviors
{
    public static class ETagComparer
    {
        public static bool IsConflict(object resource, string providedETag)
        {
            var resourceETag = ETagGenerator.Generate(resource);

            return resourceETag.Equals(providedETag);
        }
    }
}