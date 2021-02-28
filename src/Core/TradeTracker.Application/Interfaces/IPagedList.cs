using System.Collections.Generic;

namespace TradeTracker.Application.Interfaces
{
    public interface IPagedList<T>
    {
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }

        bool HasPrevious { get; set; }
        bool HasNext { get; set; }

        IEnumerable<T> Items { get; set; }
    }
}