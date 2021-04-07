using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions
{
    public class DetailedPositionForReturn
    {
        public string Symbol { get; set; }
        public string Exposure { get; set; }
        public decimal Quantity { get; set; }
        public decimal AverageCostBasis { get; set; }
        public IEnumerable<FullSourceRelation> SourceRelations { get; set; }
    }
}

