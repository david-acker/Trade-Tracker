using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, PagedTransactionsListVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionsListQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<PagedTransactionsListVm> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var pagedList = await _transactionRepository.GetPagedTransactionsList(request.AccessKey, request.PageNumber, request.PageSize);
            
            var transactionsToReturn = _mapper.Map<PagedList<Transaction>, List<TransactionDto>>(pagedList);

            return new PagedTransactionsListVm()
            {
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                HasPrevious = pagedList.HasPrevious,
                HasNext = pagedList.HasNext,
                Items = transactionsToReturn
            };
        }
    }
}
