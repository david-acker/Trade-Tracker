using MediatR;
using System;
using System.Collections.Generic;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQuery : AuthenticatedRequest, IRequest<IEnumerable<TransactionForReturnDto>>
    {
        public IEnumerable<Guid> TransactionIds { get; set; }
    }
}
