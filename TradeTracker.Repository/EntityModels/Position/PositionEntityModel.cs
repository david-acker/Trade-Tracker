namespace TradeTracker.Repository.EntityModels.Position
{
    public class PositionEntityModel
    {
        public int PositionId { get; set; }
        public string AccessKey { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }
}
