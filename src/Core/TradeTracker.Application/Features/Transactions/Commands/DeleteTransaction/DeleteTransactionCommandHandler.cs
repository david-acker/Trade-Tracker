using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public DeleteTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);  

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);    

            var transactionToDelete = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);

            if (transactionToDelete == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            await _transactionRepository.DeleteAsync(transactionToDelete);

            return Unit.Value;
        }
    }
}
