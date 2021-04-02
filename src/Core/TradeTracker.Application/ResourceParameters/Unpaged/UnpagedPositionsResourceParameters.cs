using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.ResourceParameters.Unpaged
{
    public class UnpagedPositionsResourceParameters : IUnpagedResourceParameters
    {
        public SortOrder SortOrder { get; set; }
        public Selection Selection { get; set; }
        public string Exposure { get; set; }
    }
}