using System;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsExport
{
    public class TransactionForExportDto
    {
        public Guid TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public string TransactionType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }
}
