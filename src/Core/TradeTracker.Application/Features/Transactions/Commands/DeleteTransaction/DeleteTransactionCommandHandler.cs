using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler :
        IRequestHandler<DeleteTransactionCommand>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        
        public DeleteTransactionCommandHandler( 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {   
            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            await _authenticatedTransactionRepository.DeleteAsync(transaction);

            return Unit.Value;
        }
    }
}
