using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TradeTracker.Application.Common.Models.Resources.Responses
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;

            PageSize = pageSize;
            CurrentPage = (pageNumber <= TotalPages)
                ? pageNumber
                : TotalPages;
            
            AddRange(items);
        }

        public static PagedList<T> Create(List<T> items, int pageNumber, int pageSize)
        {
            var count = items.Count();

            var itemsForPage = items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return new PagedList<T>(itemsForPage, count, pageNumber, pageSize);
        }

        public async static Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}