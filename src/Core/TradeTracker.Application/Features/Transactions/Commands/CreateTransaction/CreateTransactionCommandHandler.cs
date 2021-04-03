using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : 
        ValidatableRequestBehavior<CreateTransactionCommand>,
        IRequestHandler<CreateTransactionCommand, TransactionForReturnDto>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionForReturnDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);
            
            var transaction = _mapper.Map<Transaction>(request);

            transaction = await _authenticatedTransactionRepository.AddAsync(transaction);

            return _mapper.Map<TransactionForReturnDto>(transaction);
        }
    }
}