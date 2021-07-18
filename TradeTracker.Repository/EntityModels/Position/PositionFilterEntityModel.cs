namespace TradeTracker.Repository.EntityModels.Position
{
    public class PositionFilterEntityModel : BaseFilterEntityModel
    {
        public string AccessKey { get; set; }
        public char? PositionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }
}
