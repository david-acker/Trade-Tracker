using Autofac;
using Autofac.Extras.Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading.Tasks;
using TradeTracker.Api.Controllers;
using TradeTracker.Api.Profiles;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Position;
using Xunit;

namespace TradeTracker.Api.Test.Controllers
{
    public class PositionsControllerTests
    {
        public readonly IMapper _mapper;
        public PositionsControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PositionsProfile>();
            });

            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task ItWillReturn404NotFound()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPositionsService>()
                    .Setup(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<Position>(null));

                var controller = mock.Create<PositionsController>();

                var response = await controller.GetAsync("AAA");

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<IPositionsService>().Verify(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionsService>().Verify(x => x.GetPosition(It.Is<string>(i => i == "AAA"), It.Is<string>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturnPosition()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<IPositionsService>()
                    .Setup(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new Position
                    {
                        Symbol = "AAA",
                        Quantity = 1
                    });

                var controller = mock.Create<PositionsController>();

                var response = await controller.GetAsync("AAA");

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var position = Assert.IsType<PositionDomainModel>(result.Value);
                Assert.Equal("AAA", position.Symbol);
                Assert.Equal(1, position.Quantity);

                mock.Mock<IPositionsService>().Verify(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionsService>().Verify(x => x.GetPosition(It.Is<string>(i => i == "AAA"), It.Is<string>(i => i != null)), Times.Once);
            }
        }
    }
}
