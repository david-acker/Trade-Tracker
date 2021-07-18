namespace TradeTracker.Core.DomainModels.Position
{
    public class PositionFilterDomainModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public char? PositionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }
}
