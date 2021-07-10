using System;
using TradeTracker.Repository.EntityModels;

namespace TradeTracker.Repository.Helpers
{
    public static class PaginationHelper
    {
        public static int CalculateSkip(BaseFilterEntityModel filterModel)
        {
            return (filterModel.Page - 1) * filterModel.PageSize;
        }

        public static int CalculateTake(BaseFilterEntityModel filterModel)
        {
            return filterModel.PageSize;
        }

        public static int CalculateTotalPages(BaseFilterEntityModel filterModel, int totalRecordCount)
        {
            return (int)Math.Ceiling((decimal)totalRecordCount / (decimal)filterModel.PageSize);
        }
    }
}
