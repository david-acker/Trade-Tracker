using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.Requests;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : 
        ValidatableRequestHandler<GetTransactionsQuery>,
        IRequestHandler<GetTransactionsQuery, PagedTransactionsBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        public GetTransactionsQueryHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
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
