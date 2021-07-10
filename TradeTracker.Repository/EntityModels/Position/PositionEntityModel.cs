using System;

namespace TradeTracker.Repository.EntityModels.Position
{
    public class PositionEntityModel
    {
        public Guid PositionId { get; set; }
        public string AccessKey { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }
}
