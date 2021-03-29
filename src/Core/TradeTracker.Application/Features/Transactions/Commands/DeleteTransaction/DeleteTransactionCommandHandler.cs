using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests.ValidatedRequestHandler;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : 
        ValidatableRequestHandler<DeleteTransactionCommand, DeleteTransactionCommandValidator>,
        IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public DeleteTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            string symbolBeforeDeletion = transaction.Symbol;
            TransactionType typeBeforeDeletion = transaction.Type;
            decimal quantityBeforeDeletion = transaction.Quantity;

            transaction.DomainEvents.Add(
                new TransactionDeletedEvent(
                    accessKey: transaction.AccessKey, 
                    symbolBeforeDeletion: symbolBeforeDeletion,
                    typeBeforeDeletion: typeBeforeDeletion,
                    quantityBeforeDeletion: quantityBeforeDeletion));

            await _transactionRepository.DeleteAsync(transaction);

            return Unit.Value;
        }
    }
}
