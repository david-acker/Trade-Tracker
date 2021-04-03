using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class TransactionForReturnWithLinksDto : TransactionForReturnDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}