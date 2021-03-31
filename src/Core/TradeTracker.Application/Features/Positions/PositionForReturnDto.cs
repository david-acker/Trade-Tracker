using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions
{
    public class PositionForReturnDto
    {
        public string Symbol { get; set; }

        public string Exposure { get; set; }

        public decimal Quantity { get; set; }

        public decimal AverageCostBasis { get; set; }

        public IEnumerable<SourceTransactionLink> SourceTransactionMap { get; set; }
    }
}

