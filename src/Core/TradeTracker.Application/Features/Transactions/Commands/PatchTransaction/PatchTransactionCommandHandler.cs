using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommandHandler : IRequestHandler<PatchTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public PatchTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Unit> Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);

            if (existingTransaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            var updatedTransaction = ApplyPatch(request, existingTransaction);

            var validator = new UpdateTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(updatedTransaction);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var transactionEntity = _mapper.Map<Transaction>(updatedTransaction);
        
            await _transactionRepository.UpdateAsync(transactionEntity);

            return Unit.Value;
        }

        private UpdateTransactionCommand ApplyPatch(PatchTransactionCommand request, Transaction existingTransaction)
        {
            var transactionForPatch = _mapper.Map<UpdateTransactionCommand>(existingTransaction);

            JsonPatchDocument<UpdateTransactionCommandDto> patchDocument = request.PatchDocument;
            patchDocument.ApplyTo(transactionForPatch);
            
            transactionForPatch.AccessKey = request.AccessKey;
            transactionForPatch.TransactionId = request.TransactionId;

            return transactionForPatch;
        }
    }
}