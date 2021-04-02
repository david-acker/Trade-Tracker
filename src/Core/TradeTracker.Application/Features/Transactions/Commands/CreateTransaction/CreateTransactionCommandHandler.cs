using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : 
        ValidatableRequestHandler<CreateTransactionCommand>,
        IRequestHandler<CreateTransactionCommand, TransactionForReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;

        public CreateTransactionCommandHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
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