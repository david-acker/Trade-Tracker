using Autofac;
using Autofac.Extras.Moq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TradeTracker.Api.Controllers;
using TradeTracker.Api.DTOs;
using TradeTracker.Api.DTOs.Position;
using TradeTracker.Api.Profiles;
using TradeTracker.Api.Services;
using TradeTracker.Api.Test.Base;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Position;
using Xunit;

namespace TradeTracker.Api.Test.Controllers
{
    public class PositionsControllerTests : ControllerTestBase
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
                mock.Mock<ICurrentUserService>()
                    .SetupGet(x => x.AccessKey)
                    .Returns("AccessKey");

                mock.Mock<IPositionService>()
                    .Setup(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<PositionDomainModel>(null));

                var controller = mock.Create<PositionsController>();

                var response = await controller.GetAsync("AAA");

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.Is<string>(i => i == "AAA"), It.Is<string>(i => i == "AccessKey")), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturnPosition()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ICurrentUserService>()
                    .SetupGet(x => x.AccessKey)
                    .Returns("AccessKey");

                mock.Mock<IPositionService>()
                    .Setup(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new PositionDomainModel
                    {
                        Symbol = "AAA",
                        Quantity = 1
                    });

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(false);

                var controller = mock.Create<PositionsController>();

                SetRequestHeader(controller, "Accept", "application/vnd.trade.position+json");

                var response = await controller.GetAsync("AAA");

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var position = Assert.IsType<PositionDto>(result.Value);

                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.Is<string>(i => i == "AAA"), It.Is<string>(i => i == "AccessKey")), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.position+json")));
            }
        }

        [Fact]
        public async Task ItWillReturnLinkedPosition()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ICurrentUserService>()
                    .SetupGet(x => x.AccessKey)
                    .Returns("AccessKey");

                mock.Mock<IPositionService>()
                    .Setup(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(new PositionDomainModel
                    {
                        Symbol = "AAA",
                        Quantity = 1
                    });

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(true);

                var controller = mock.Create<PositionsController>();

                var urlHelperMock = new Mock<IUrlHelper>();
                urlHelperMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(string.Empty);
                controller.Url = urlHelperMock.Object;

                SetRequestHeader(controller, "Accept", "application/vnd.trade.position.hateoas+json");

                var response = await controller.GetAsync("AAA");

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var linkedPosition = Assert.IsType<LinkedPositionDto>(result.Value);

                var position = linkedPosition.Position;
                Assert.NotNull(position);
                Assert.Equal("AAA", position.Symbol);
                Assert.Equal(1, position.Quantity);

                var links = linkedPosition.Links;
                Assert.NotNull(links);

                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.GetPosition(It.Is<string>(i => i == "AAA"), It.Is<string>(i => i == "AccessKey")), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.position.hateoas+json")));
            }
        }

        [Fact]
        public async Task ItWillReturnFilteredPositions()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ICurrentUserService>()
                    .SetupGet(x => x.AccessKey)
                    .Returns("AccessKey");

                mock.Mock<IPositionService>()
                    .Setup(x => x.ValidatePositionFilterModel(It.IsAny<PositionFilterDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<IPositionService>()
                    .Setup(x => x.GetFilteredPositions(It.IsAny<PositionFilterDomainModel>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(new PaginatedResult<PositionDomainModel>(new List<PositionDomainModel>() { new PositionDomainModel() }, new PaginationMetadata())));

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(false);

                var controller = mock.Create<PositionsController>();

                SetRequestHeader(controller, "Accept", "application/vnd.trade.position.paged+json");

                var response = await controller.GetFilteredAsync(
                    new PositionFilterDto
                    {
                        Page = 1,
                        PageSize = 10
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var positions = Assert.IsType<PaginatedResult<PositionDto>>(result.Value);
                Assert.NotNull(positions);
                Assert.Single(positions.Results);

                mock.Mock<IPositionService>().Verify(x => x.ValidatePositionFilterModel(It.IsAny<PositionFilterDomainModel>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.ValidatePositionFilterModel(It.Is<PositionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10)), Times.Once);

                mock.Mock<IPositionService>().Verify(x => x.GetFilteredPositions(It.IsAny<PositionFilterDomainModel>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.GetFilteredPositions(It.Is<PositionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10), It.Is<string>(i => i == "AccessKey")), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.position.paged+json")));
            }
        }

        [Fact]
        public async Task ItWillReturnFilteredLinkedPositions()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ICurrentUserService>()
                    .SetupGet(x => x.AccessKey)
                    .Returns("AccessKey");

                mock.Mock<IPositionService>()
                    .Setup(x => x.ValidatePositionFilterModel(It.IsAny<PositionFilterDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<IPositionService>()
                    .Setup(x => x.GetFilteredPositions(It.IsAny<PositionFilterDomainModel>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(new PaginatedResult<PositionDomainModel>(new List<PositionDomainModel>() { new PositionDomainModel() }, new PaginationMetadata())));

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(true);

                var controller = mock.Create<PositionsController>();

                var urlHelperMock = new Mock<IUrlHelper>();
                urlHelperMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(string.Empty);
                controller.Url = urlHelperMock.Object;

                SetRequestHeader(controller, "Accept", "application/vnd.trade.position.paged.hateoas+json");

                var response = await controller.GetFilteredAsync(
                    new PositionFilterDto
                    {
                        Page = 1,
                        PageSize = 10
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var Positions = Assert.IsType<LinkedPaginatedResult<LinkedPositionDto>>(result.Value);
                Assert.NotNull(Positions);

                Assert.Single(Positions.Results);
                Assert.NotNull(Positions.Results.FirstOrDefault().Links);

                Assert.NotNull(Positions.Metadata);

                mock.Mock<IPositionService>().Verify(x => x.ValidatePositionFilterModel(It.IsAny<PositionFilterDomainModel>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.ValidatePositionFilterModel(It.Is<PositionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10)), Times.Once);

                mock.Mock<IPositionService>().Verify(x => x.GetFilteredPositions(It.IsAny<PositionFilterDomainModel>(), It.IsAny<string>()), Times.Once);
                mock.Mock<IPositionService>().Verify(x => x.GetFilteredPositions(It.Is<PositionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10), It.Is<string>(i => i == "AccessKey")), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.position.paged.hateoas+json")));
            }
        }

        [Fact]
        public void ItWillReturnOptions()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var controller = mock.Create<PositionsController>();

                var headerDictionary = new HeaderDictionary();

                var responseMock = new Mock<HttpResponse>();
                responseMock.SetupGet(x => x.Headers).Returns(headerDictionary);

                var httpContextMock = new Mock<HttpContext>();
                httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

                controller.ControllerContext.HttpContext = httpContextMock.Object;

                var response = controller.Options();

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                var headers = controller.Response.Headers;
                Assert.NotEmpty(headers);

                var allowHeader = Assert.Contains("Allow", headers);
                Assert.Equal("GET,OPTIONS", allowHeader.SingleOrDefault());
            }
        }

        [Fact]
        public void ItWillReturnOptionsForSymbol()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var controller = mock.Create<PositionsController>();

                var headerDictionary = new HeaderDictionary();

                var responseMock = new Mock<HttpResponse>();
                responseMock.SetupGet(x => x.Headers).Returns(headerDictionary);

                var httpContextMock = new Mock<HttpContext>();
                httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

                controller.ControllerContext.HttpContext = httpContextMock.Object;

                var response = controller.OptionsForSymbol();

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                var headers = controller.Response.Headers;
                Assert.NotEmpty(headers);

                var allowHeader = Assert.Contains("Allow", headers);
                Assert.Equal("GET,OPTIONS", allowHeader.SingleOrDefault());
            }
        }
    }
}
