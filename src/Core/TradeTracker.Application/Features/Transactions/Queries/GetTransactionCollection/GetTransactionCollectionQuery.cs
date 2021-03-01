using MediatR;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public string AccessKey { get; set; }
        public IEnumerable<Guid> TransactionIds { get; set; }
    }
}
