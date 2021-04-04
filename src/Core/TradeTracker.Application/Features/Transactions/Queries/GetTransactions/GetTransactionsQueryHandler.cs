using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : 
        ValidatableRequestBehavior<GetTransactionsQuery>,
        IRequestHandler<GetTransactionsQuery, PagedTransactionsBaseDto>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        public GetTransactionsQueryHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedTransactionsBaseDto> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedTransactionsResourceParameters>(request);

            var pagedTransactions = await _authenticatedTransactionRepository
                .GetPagedResponseAsync(parameters);
            
            var transactionsForReturn = _mapper.Map<PagedList<Transaction>, List<TransactionForReturnDto>>(pagedTransactions);

            return new PagedTransactionsBaseDto()
            {
                CurrentPage = pagedTransactions.CurrentPage,
                TotalPages = pagedTransactions.TotalPages,
                PageSize = pagedTransactions.PageSize,
                TotalCount = pagedTransactions.TotalCount,
                HasPrevious = pagedTransactions.HasPrevious,
                HasNext = pagedTransactions.HasNext,
                Items = transactionsForReturn
            };
        }
    }
}
