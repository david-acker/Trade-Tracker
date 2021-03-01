using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQuery : IRequest<PagedTransactionsListVm>
    {
        public string AccessKey { get; set; }

        public int PageNumber { get; set; } = 1;

        const int MaxPageSize = 100;
        
        private int _pageSize = 25;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
