using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class SummaryProfile
    {
        public string TransactionType { get; set; }
        public SummaryInformation SummaryInformation { get; set; }
    }
}