using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler :
        IRequestHandler<DeleteTransactionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        
        public DeleteTransactionCommandHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {   
            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            await _authenticatedTransactionRepository.DeleteAsync(transaction);

            return Unit.Value;
        }
    }
}
