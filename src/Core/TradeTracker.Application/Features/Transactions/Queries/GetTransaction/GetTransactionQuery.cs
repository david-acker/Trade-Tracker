using MediatR;
using System;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQuery : IRequest<TransactionDto>
    {
        public string AccessTag { get; set; }
        public Guid TransactionId { get; set; }
    }
}
