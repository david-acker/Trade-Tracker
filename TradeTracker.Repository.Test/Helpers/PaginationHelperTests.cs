using TradeTracker.Repository.EntityModels;
using TradeTracker.Repository.Helpers;
using Xunit;

namespace TradeTracker.Repository.Test.Helpers
{
    public class PaginationHelperTests
    {
        [Fact]
        public void ItWillCalculateSkip()
        {
            var filterModel = new BaseFilterEntityModel
            {
                Page = 3,
                PageSize = 25
            };

            var skip = PaginationHelper.CalculateSkip(filterModel);

            Assert.Equal(50, skip);
        }

        [Fact]
        public void ItWillReturnDefaultSkip()
        {
            var filterModel = new BaseFilterEntityModel
            {
                Page = -1,
                PageSize = -1
            };

            var skip = PaginationHelper.CalculateSkip(filterModel);

            Assert.Equal(PaginationHelper.DefaultSkip, skip);
        }

        [Fact]
        public void ItWillCalculateTake()
        {
            var filterModel = new BaseFilterEntityModel
            {
                Page = 3,
                PageSize = 25
            };

            var take = PaginationHelper.CalculateTake(filterModel);

            Assert.Equal(25, take);
        }

        [Fact]
        public void ItWillReturnDefaultTake()
        {
            var filterModel = new BaseFilterEntityModel
            {
                Page = -1,
                PageSize = -1
            };

            var take = PaginationHelper.CalculateTake(filterModel);

            Assert.Equal(PaginationHelper.DefaultTake, take);
        }

        [Fact]
        public void ItWillCalculateTotalPages()
        {
            var filterModel = new BaseFilterEntityModel
            {
                Page = 1,
                PageSize = 25
            };

            int totalRecordCount = 90;

            var totalPages = PaginationHelper.CalculateTotalPages(filterModel, totalRecordCount);

            Assert.Equal(4, totalPages);
        }
    }
}
