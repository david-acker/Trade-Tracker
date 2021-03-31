using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommandHandler :
        ValidatableRequestHandler<UpdateTransactionCommand>,
        IRequestHandler<PatchTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public PatchTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);

            if (existingTransaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            string symbolBeforeModification = existingTransaction.Symbol;
            TransactionType typeBeforeModification = existingTransaction.Type;
            decimal quantityBeforeModification = existingTransaction.Quantity;           

            var updatedTransactionCommand = ApplyPatch(request, existingTransaction);
            await ValidateRequest(updatedTransactionCommand);

            var transaction = _mapper.Map<Transaction>(updatedTransactionCommand);

            transaction.DomainEvents.Add(
                new TransactionModifiedEvent(
                    accessKey: transaction.AccessKey,
                    transactionId: transaction.TransactionId, 
                    symbolBeforeModification: symbolBeforeModification,
                    typeBeforeModification: typeBeforeModification,
                    quantityBeforeModification: quantityBeforeModification));
        
            await _transactionRepository.UpdateAsync(transaction);

            return Unit.Value;
        }

        private UpdateTransactionCommand ApplyPatch(PatchTransactionCommand request, Transaction existingTransaction)
        {
            var transactionForPatch = _mapper.Map<UpdateTransactionCommand>(existingTransaction);

            JsonPatchDocument<UpdateTransactionCommandBase> patchDocument = request.PatchDocument;
            patchDocument.ApplyTo(transactionForPatch);
            
            transactionForPatch.Authenticate(request.AccessKey);
            transactionForPatch.TransactionId = request.TransactionId;

            return transactionForPatch;
        }
    }
}