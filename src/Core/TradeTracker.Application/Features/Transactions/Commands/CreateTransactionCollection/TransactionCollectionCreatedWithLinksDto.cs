using System.Collections.Generic;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class TransactionCollectionCreatedWithLinksDto
    {
        public IEnumerable<TransactionWithLinksForReturnDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}