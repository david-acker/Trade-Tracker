using MediatR;
using System;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQuery : AuthenticatedRequest, IRequest<TransactionForReturnDto>
    {
        public Guid TransactionId { get; set; }
    }
}
