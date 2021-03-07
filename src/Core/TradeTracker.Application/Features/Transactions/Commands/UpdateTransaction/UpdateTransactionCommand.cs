using System;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : UpdateTransactionCommandDto, IRequest
    {
        public Guid AccessKey { get; set; }
        public Guid TransactionId { get; set; }
    }
}
