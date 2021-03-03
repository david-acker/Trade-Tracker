using System;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : UpdateTransactionCommandDto, IRequest
    {
        public string AccessKey { get; set; }
        public Guid TransactionId { get; set; }
    }
}
