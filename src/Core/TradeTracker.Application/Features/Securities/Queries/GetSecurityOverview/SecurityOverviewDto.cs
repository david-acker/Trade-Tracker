namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class SecurityOverviewDto
    {
        public SummaryGroup YearToDate { get; set; }
        public SummaryGroup PreviousYear { get; set; }
        public SummaryGroup CompleteHistory { get; set; }
    }
}
