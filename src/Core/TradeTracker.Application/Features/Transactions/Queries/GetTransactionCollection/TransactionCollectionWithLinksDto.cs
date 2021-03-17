using System.Collections.Generic;
using TradeTracker.Api.Models.Pagination;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class TransactionCollectionWithLinksDto
    {
        public IEnumerable<TransactionWithLinksForReturnDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}