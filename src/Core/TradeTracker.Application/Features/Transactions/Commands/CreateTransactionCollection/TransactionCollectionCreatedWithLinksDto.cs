using System.Collections.Generic;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class TransactionCollectionCreatedWithLinksDto
    {
        public IEnumerable<TransactionForReturnWithLinksDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}