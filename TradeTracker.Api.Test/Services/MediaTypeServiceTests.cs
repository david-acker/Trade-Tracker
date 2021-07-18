using TradeTracker.Api.Services;
using Xunit;

namespace TradeTracker.Api.Test.Services
{
    public class MediaTypeServiceTests
    {
        [Theory]
        [InlineData("application/vnd.trade.transaction+json", false)]
        [InlineData("application/vnd.trade.transaction.hateoas+json", true)]
        public void ItWillReturnTrueIfLinkedRepresentation(string acceptHeader, bool expected)
        {
            var service = new MediaTypeService();

            var result = service.IsLinkedRepresentation(acceptHeader);

            Assert.Equal(expected, result);
        }
    }
}
