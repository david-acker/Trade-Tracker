using System;
using TradeTracker.Repository.EntityModels;

namespace TradeTracker.Repository.Helpers
{
    public static class PaginationHelper
    {
        public static int DefaultSkip = 0;
        public static int DefaultTake = 25;

        public static int CalculateSkip(BaseFilterEntityModel filterModel)
        {
            bool isValid = (filterModel.Page > 0) && (filterModel.PageSize > 0);
            
            if (!isValid)
            {
                return DefaultSkip;
            }

            return (filterModel.Page - 1) * filterModel.PageSize;            
        }

        public static int CalculateTake(BaseFilterEntityModel filterModel)
        {
            return (filterModel.PageSize > 0) ? filterModel.PageSize : DefaultTake;
        }

        public static int CalculateTotalPages(BaseFilterEntityModel filterModel, int totalRecordCount)
        {
            return (int)Math.Ceiling((decimal)totalRecordCount / (decimal)filterModel.PageSize);
        }
    }
}
