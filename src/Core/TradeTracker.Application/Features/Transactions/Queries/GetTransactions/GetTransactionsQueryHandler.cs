using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.Requests.ValidatedRequestHandler;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : 
        ValidatableRequestHandler<GetTransactionsQuery, GetTransactionsQueryValidator>,
        IRequestHandler<GetTransactionsQuery, PagedTransactionsBaseDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionsQueryHandler(
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<PagedTransactionsBaseDto> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedTransactionsResourceParameters>(request);

            var pagedTransactions = await _transactionRepository.GetPagedTransactionsAsync(parameters);
            
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
