using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : 
        ValidatableRequestHandler<GetTransactionQuery>,
        IRequestHandler<GetTransactionQuery, TransactionForReturnDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionForReturnDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            Guid userAccessKey = _loggedInUserService.AccessKey;

            var transaction = await _transactionRepository.GetByIdAsync(userAccessKey, request.TransactionId);
            
            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }
            
            var transactionForReturnDto = _mapper.Map<TransactionForReturnDto>(transaction);

            return transactionForReturnDto;
        }
    }
}
