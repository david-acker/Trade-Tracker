using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommandHandler :
        ValidatableRequestBehavior<UpdateTransactionCommand>,
        IRequestHandler<PatchTransactionCommand>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IETagService _eTagService;
         private readonly IMapper _mapper;
        public PatchTransactionCommandHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IETagService eTagService,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _eTagService = eTagService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);

            if (existingTransaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            var ifMatchHeader = _eTagService.GetETagFromHeader();
            
            if (!String.IsNullOrWhiteSpace(ifMatchHeader))
            {
                var transactionForReturn = _mapper.Map<TransactionForReturnDto>(existingTransaction);

                if (ETagComparer.IsConflict(transactionForReturn, ifMatchHeader))
                {
                    throw new ResourceStateConflictException($"The representation of the {typeof(Transaction)} ({request.TransactionId}) was changed.");
                }
            }

            string symbolBeforeModification = existingTransaction.Symbol;
            TransactionType typeBeforeModification = existingTransaction.Type;
            decimal quantityBeforeModification = existingTransaction.Quantity;           

            var updatedTransactionCommand = ApplyPatch(request, existingTransaction);
            await ValidateRequest(updatedTransactionCommand);

            var transaction = _mapper.Map<Transaction>(updatedTransactionCommand);

            transaction.DomainEvents.Add(
                new TransactionModifiedEvent(
                    transaction.AccessKey,
                    transaction.TransactionId, 
                    symbolBeforeModification,
                    typeBeforeModification,
                    quantityBeforeModification));
        
            await _authenticatedTransactionRepository.UpdateAsync(transaction);

            return Unit.Value;
        }

        private UpdateTransactionCommand ApplyPatch(
            PatchTransactionCommand request, 
            Transaction existingTransaction)
        {
            var transactionForPatch = _mapper.Map<UpdateTransactionCommand>(existingTransaction);

            JsonPatchDocument<UpdateTransactionCommandBase> patchDocument = request.PatchDocument;
            patchDocument.ApplyTo(transactionForPatch);

            return transactionForPatch;
        }
    }
}