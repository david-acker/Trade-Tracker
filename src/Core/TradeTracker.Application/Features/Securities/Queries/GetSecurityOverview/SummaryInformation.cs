namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class SummaryInformation
    {
        public int NumberOfTrades  { get; set; }
        public SummaryInformationBlock Quantity { get; set; }
        public SummaryInformationBlock Notional { get; set; }
    }
}