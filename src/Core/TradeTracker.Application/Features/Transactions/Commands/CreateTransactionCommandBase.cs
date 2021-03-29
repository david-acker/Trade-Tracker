using System;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommandBase : AuthenticatedRequest
    {
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
        public decimal TradePrice { get; set; }
    }
}