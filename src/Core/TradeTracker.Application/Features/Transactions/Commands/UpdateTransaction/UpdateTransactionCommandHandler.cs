using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            string symbolBeforeModification = transaction.Symbol;
            TransactionType typeBeforeModification = transaction.Type;
            decimal quantityBeforeModification = transaction.Quantity;

            _mapper.Map(request, transaction, typeof(UpdateTransactionCommand), typeof(Transaction));

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

        public async Task ValidateRequest(UpdateTransactionCommand request)
        {
            var validator = new UpdateTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
        }
    }
}