using System;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommand : IRequest
    {
        public Guid AccessKey { get; set; }
        public Guid TransactionId { get; set; }
        public JsonPatchDocument<UpdateTransactionCommandDto> PatchDocument { get; set; }
    }
}
