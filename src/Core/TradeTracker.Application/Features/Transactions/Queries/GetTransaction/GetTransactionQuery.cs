using MediatR;
using System;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQuery : IRequest<TransactionForReturnDto>
    {
        public Guid AccessKey { get; set; }
        public Guid TransactionId { get; set; }
    }
}
