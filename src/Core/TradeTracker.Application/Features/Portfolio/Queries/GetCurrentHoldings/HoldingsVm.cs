using System;

namespace TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings
{
    public class HoldingVm
    {
        public string Symbol { get; set; }
        public decimal NetQuantity { get; set; }
    }
}