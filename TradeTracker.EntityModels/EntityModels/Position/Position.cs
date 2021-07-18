using System;

namespace TradeTracker.EntityModels.Models.Position
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string AccessKey { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }
}
