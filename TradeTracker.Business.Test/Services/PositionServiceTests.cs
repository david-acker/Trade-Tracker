using Autofac.Extras.Moq;
using System.Linq;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Position;
using Xunit;

namespace TradeTracker.Business.Test.Services
{
    public class PositionServiceTests
    {
        [Fact]
        public void ItWillValidatePositionFilterModel()
        {
            var filterModel = new PositionFilterDomainModel
            {
                Page = 1,
                PageSize = 25,
                PositionType = 'L',
                OrderByField = "Symbol",
                OrderByDirection = 'A'
            };

            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<PositionService>();

                var result = service.ValidatePositionFilterModel(filterModel);

                Assert.NotNull(result);
                Assert.Empty(result);
                Assert.True(result.IsValid);
            }
        }

        [Fact]
        public void ItWillInvalidatePositionFilterModel()
        {
            var filterModel = new PositionFilterDomainModel
            {
                Page = -1,
                PageSize = -25,
                PositionType = '0',
                OrderByField = "FakeField",
                OrderByDirection = '0'
            };

            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<PositionService>();

                var result = service.ValidatePositionFilterModel(filterModel);

                Assert.NotNull(result);
                Assert.Equal(5, result.Count());
                Assert.False(result.IsValid);
            }
        }
    }
}
