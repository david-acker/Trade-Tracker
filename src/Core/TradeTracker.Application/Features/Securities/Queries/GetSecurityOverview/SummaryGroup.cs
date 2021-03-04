using System.Collections.Generic;

namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class SummaryGroup
    {
        public SummaryInformation Overall { get; set; }
        public IEnumerable<SummaryProfile> ByTransactionType { get; set; }
    }
}