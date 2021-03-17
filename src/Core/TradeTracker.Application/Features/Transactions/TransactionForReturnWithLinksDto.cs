using System.Collections.Generic;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class TransactionForReturnWithLinksDto : TransactionForReturnDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}