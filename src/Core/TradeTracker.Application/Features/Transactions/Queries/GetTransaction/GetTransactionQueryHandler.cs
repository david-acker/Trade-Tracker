using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : 
        ValidatableRequestBehavior<GetTransactionQuery>,
        IRequestHandler<GetTransactionQuery, TransactionForReturnDto>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionQueryHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionForReturnDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.Id);
            
            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }
            
            var transactionForReturnDto = _mapper.Map<TransactionForReturnDto>(transaction);

            return transactionForReturnDto;
        }
    }
}
