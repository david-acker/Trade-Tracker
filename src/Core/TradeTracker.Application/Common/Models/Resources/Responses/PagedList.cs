using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TradeTracker.Application.Common.Models.Resources.Responses
{
    public class PagedList<T> : List<T>
    {
        private const int defaultPageNumber = 1;
        private const int defaultPageSize = 25;
        private const int minPageSize = 1;
        private const int maxPageSize = 100;

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);

        public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;

            PageSize = pageSize;
            CurrentPage = pageNumber;
            
            AddRange(items);
        }

        public static PagedList<T> Create(
            List<T> items, 
            int pageNumber, 
            int pageSize)
        {
            pageNumber = ConfirmPageNumber(pageNumber);
            pageSize = ConfirmPageSize(pageSize);

            var count = items.Count();

            var itemsForPage = items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return new PagedList<T>(itemsForPage, count, pageNumber, pageSize);
        }

        public async static Task<PagedList<T>> CreateAsync(
            IQueryable<T> source, 
            int pageNumber, 
            int pageSize)
        {
            pageNumber = ConfirmPageNumber(pageNumber);
            pageSize = ConfirmPageSize(pageSize);

            var count = source.Count();

            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        private static int ConfirmPageNumber(int pageNumber)
        {
            return (pageNumber > 0)
                ? pageNumber
                : defaultPageNumber;
        }

        private static int ConfirmPageSize(int pageSize)
        {
            int pageSizeToReturn;

            switch (pageSize)
            {
                case int size when size < minPageSize:
                    pageSizeToReturn = minPageSize;
                    break;
                
                case int size when size > maxPageSize:
                    pageSizeToReturn = maxPageSize;
                    break;
                
                default:
                    pageSizeToReturn = pageSize;
                    break;
            }
            
            return pageSizeToReturn;
        }
    }
}