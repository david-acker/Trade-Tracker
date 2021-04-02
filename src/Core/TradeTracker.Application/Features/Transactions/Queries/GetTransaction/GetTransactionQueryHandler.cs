using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : 
        ValidatableRequestHandler<GetTransactionQuery>,
        IRequestHandler<GetTransactionQuery, TransactionForReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        public GetTransactionQueryHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<TransactionForReturnDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);
            
            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }
            
            var transactionForReturnDto = _mapper.Map<TransactionForReturnDto>(transaction);

            return transactionForReturnDto;
        }
    }
}
