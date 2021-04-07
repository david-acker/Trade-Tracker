using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class TransactionForReturnWithLinks : TransactionForReturn
    {
        public IEnumerable<Link> Links { get; set; }
    }
}