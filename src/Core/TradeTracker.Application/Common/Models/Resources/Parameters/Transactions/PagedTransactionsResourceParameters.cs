using System;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Models.Resources.Parameters.Transactions
{
    public class PagedTransactionsResourceParameters : IPagedResourceParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public ITransactionOrderBy OrderBy { get; set; } = new NullTransactionOrderBy();
        public TransactionType TransactionType { get; set; } = TransactionType.NotSpecified;
        public ISymbolSelection SymbolSelection { get; set; } = new NullSymbolSelection();
        public DateTime RangeStart { get; set; } = DateTime.MinValue.Date;
        public DateTime RangeEnd { get; set; } = DateTime.MinValue.Date;
    }
}