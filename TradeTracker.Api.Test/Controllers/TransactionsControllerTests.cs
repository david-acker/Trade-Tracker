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
using TradeTracker.Api.DTOs.Transaction;
using TradeTracker.Api.Profiles;
using TradeTracker.Api.Services;
using TradeTracker.Api.Test.Base;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Transaction;
using Xunit;

namespace TradeTracker.Api.Test.Controllers
{
    public class TransactionsControllerTests : ControllerTestBase
    {
        public readonly IMapper _mapper; 
        public TransactionsControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsProfile>();
            });

            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task ItWillReturn422ForInvalidInput_Create()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(() =>
                    {
                        var modelState = new ModelStateDictionary();
                        modelState.AddModelError("Key", "Error Message");
                        return modelState;
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.CreateAsync(new TransactionInputDto());

                Assert.NotNull(response);
                var result = Assert.IsType<UnprocessableEntityObjectResult>(response);
                Assert.Equal(HttpStatusCode.UnprocessableEntity, (HttpStatusCode)result.StatusCode);

                var errors = Assert.IsType<SerializableError>(result.Value);
                Assert.Single(errors);

                var error = errors.SingleOrDefault();
                Assert.Equal("Key", error.Key);
                Assert.Equal("Error Message", ((string[])error.Value).SingleOrDefault());

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.IsAny<TransactionDomainModel>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnTransaction_Create()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.CreateTransaction(It.IsAny<TransactionDomainModel>()))
                    .ReturnsAsync(new TransactionDomainModel
                    {
                        TransactionId = 1,
                        Symbol = "AAA"
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.CreateAsync(
                    new TransactionInputDto
                    {
                        Symbol = "AAA"
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<CreatedAtActionResult>(response);
                Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
                Assert.Equal(nameof(TransactionsController.GetAsync), result.ActionName);
                Assert.Equal(1, result.RouteValues.SingleOrDefault().Value);

                var transaction = Assert.IsType<TransactionDomainModel>(result.Value);
                Assert.Equal(1, transaction.TransactionId);
                Assert.Equal("AAA", transaction.Symbol);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturnTransaction_CreateLinked()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.CreateTransaction(It.IsAny<TransactionDomainModel>()))
                    .ReturnsAsync(new TransactionDomainModel
                    {
                        TransactionId = 1,
                        Symbol = "AAA"
                    });

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(true);

                var controller = mock.Create<TransactionsController>();

                var urlHelperMock = new Mock<IUrlHelper>();
                urlHelperMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(string.Empty);
                controller.Url = urlHelperMock.Object;
                
                SetRequestHeader(controller, "Accept", "application/vnd.trade.transaction.hateoas+json");

                var response = await controller.CreateAsync(
                    new TransactionInputDto
                    {
                        Symbol = "AAA"
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<CreatedAtActionResult>(response);
                Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
                Assert.Equal(nameof(TransactionsController.GetAsync), result.ActionName);
                Assert.Equal(1, result.RouteValues.SingleOrDefault().Value);

                var transaction = Assert.IsType<TransactionDomainModel>(result.Value);
                Assert.Equal(1, transaction.TransactionId);
                Assert.Equal("AAA", transaction.Symbol);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.transaction.hateoas+json")));

                urlHelperMock.Verify(x => x.Link(It.IsAny<string>(), It.IsAny<object>()), Times.AtLeastOnce);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Get()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<TransactionDomainModel>(null));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.GetAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillGetTransaction_Get()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(
                        new TransactionDomainModel
                        {
                            TransactionId = 1,
                            Symbol = "AAA"
                        }));

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(false);

                var controller = mock.Create<TransactionsController>();
                SetRequestHeader(controller, "Accept", "application/vnd.trade.transaction+json");

                var response = await controller.GetAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var transaction = Assert.IsType<TransactionDomainModel>(result.Value);
                Assert.Equal(1, transaction.TransactionId);
                Assert.Equal("AAA", transaction.Symbol);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.transaction+json")));
            }
        }

        [Fact]
        public async Task ItWillGetTransaction_GetLinked()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(
                        new TransactionDomainModel
                        {
                            TransactionId = 1,
                            Symbol = "AAA"
                        }));

                mock.Mock<IMediaTypeService>()
                    .Setup(x => x.IsLinkedRepresentation(It.IsAny<string>()))
                    .Returns(true);

                var controller = mock.Create<TransactionsController>();

                var urlHelperMock = new Mock<IUrlHelper>();
                urlHelperMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(string.Empty);
                controller.Url = urlHelperMock.Object;

                SetRequestHeader(controller, "Accept", "application/vnd.trade.transaction.hateoas+json");

                var response = await controller.GetAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var linkedTransaction = Assert.IsType<LinkedTransactionDto>(result.Value);

                var transaction = linkedTransaction.Transaction;
                Assert.NotNull(transaction);
                Assert.Equal(1, transaction.TransactionId);
                Assert.Equal("AAA", transaction.Symbol);

                var links = linkedTransaction.Links;
                Assert.NotNull(links);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.IsAny<string>()), Times.Once);
                mock.Mock<IMediaTypeService>().Verify(x => x.IsLinkedRepresentation(It.Is<string>(i => i == "application/vnd.trade.transaction.hateoas+json")));

                urlHelperMock.Verify(x => x.Link(It.IsAny<string>(), It.IsAny<object>()), Times.AtLeastOnce);
            }
        }

        [Fact]
        public async Task ItWillReturnFilteredTransactions()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransactionFilterModel(It.IsAny<TransactionFilterDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetFilteredTransactions(It.IsAny<TransactionFilterDomainModel>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(new PaginatedResult<TransactionDomainModel>(new List<TransactionDomainModel>() { new TransactionDomainModel() }, new PaginationMetadata())));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.GetFilteredAsync(
                    new TransactionFilterDto
                    {
                        Page = 1,
                        PageSize = 10
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var transactions = Assert.IsType<PaginatedResult<TransactionDomainModel>>(result.Value);
                Assert.NotNull(transactions);
                Assert.Single(transactions.Results);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransactionFilterModel(It.IsAny<TransactionFilterDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransactionFilterModel(It.Is<TransactionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.GetFilteredTransactions(It.IsAny<TransactionFilterDomainModel>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetFilteredTransactions(It.Is<TransactionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10), It.Is<string>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturn422ForInvalidInput_GetFiltered()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransactionFilterModel(It.IsAny<TransactionFilterDomainModel>()))
                    .Returns(() =>
                    {
                        var modelState = new ModelStateDictionary();
                        modelState.AddModelError("Key", "Error Message");
                        return modelState;
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.GetFilteredAsync(new TransactionFilterDto
                {
                    Page = 1,
                    PageSize = 10
                });

                Assert.NotNull(response);
                var result = Assert.IsType<UnprocessableEntityObjectResult>(response);
                Assert.Equal(HttpStatusCode.UnprocessableEntity, (HttpStatusCode)result.StatusCode);

                var errors = Assert.IsType<SerializableError>(result.Value);
                Assert.Single(errors);

                var error = errors.SingleOrDefault();
                Assert.Equal("Key", error.Key);
                Assert.Equal("Error Message", ((string[])error.Value).SingleOrDefault());

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransactionFilterModel(It.IsAny<TransactionFilterDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransactionFilterModel(It.Is<TransactionFilterDomainModel>(i => i != null && i.Page == 1 && i.PageSize == 10)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.GetFilteredTransactions(It.IsAny<TransactionFilterDomainModel>(), It.IsAny<string>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Update()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<TransactionDomainModel>(null));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, new TransactionInputDto());

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Never);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<TransactionDomainModel>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturn422ForInvalidInput_Update()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new TransactionDomainModel());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(() =>
                    {
                        var modelState = new ModelStateDictionary();
                        modelState.AddModelError("Key", "Error Message");
                        return modelState;
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, new TransactionInputDto());

                Assert.NotNull(response);
                var result = Assert.IsType<UnprocessableEntityObjectResult>(response);
                Assert.Equal(HttpStatusCode.UnprocessableEntity, (HttpStatusCode)result.StatusCode);

                var errors = Assert.IsType<SerializableError>(result.Value);
                Assert.Single(errors);

                var error = errors.SingleOrDefault();
                Assert.Equal("Key", error.Key);
                Assert.Equal("Error Message", ((string[])error.Value).SingleOrDefault());

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<TransactionDomainModel>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnNoContent_Update()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new TransactionDomainModel
                    {
                        TransactionId = 1,
                        Symbol = "AAA",
                        Quantity = 1,
                        TradePrice = 10
                    });

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.UpdateTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(Task.CompletedTask);

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, 
                    new TransactionInputDto
                    {
                        Symbol = "BBB",
                        Quantity = 2,
                        TradePrice = 20
                    });

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.Is<TransactionDomainModel>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Delete()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<TransactionDomainModel>(null));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.DeleteAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.IsAny<TransactionDomainModel>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnNoContent_Delete()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new TransactionDomainModel
                    {
                        TransactionId = 1
                    });

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.DeleteTransaction(It.IsAny<TransactionDomainModel>()))
                    .Returns(Task.CompletedTask);

                var controller = mock.Create<TransactionsController>();

                var response = await controller.DeleteAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.IsAny<TransactionDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.Is<TransactionDomainModel>(i => i != null && i.TransactionId == 1)), Times.Once);
            }
        }

        [Fact]
        public void ItWillReturnOptions()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var controller = mock.Create<TransactionsController>();

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
                Assert.Equal("GET,OPTIONS,POST", allowHeader.SingleOrDefault());
            }
        }

        [Fact]
        public void ItWillReturnOptionsForTransactionId()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var controller = mock.Create<TransactionsController>();

                var headerDictionary = new HeaderDictionary();

                var responseMock = new Mock<HttpResponse>();
                responseMock.SetupGet(x => x.Headers).Returns(headerDictionary);

                var httpContextMock = new Mock<HttpContext>();
                httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

                controller.ControllerContext.HttpContext = httpContextMock.Object;

                var response = controller.OptionsForTransactionId();

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                var headers = controller.Response.Headers;
                Assert.NotEmpty(headers);

                var allowHeader = Assert.Contains("Allow", headers);
                Assert.Equal("DELETE,GET,OPTIONS,PUT", allowHeader.SingleOrDefault());
            }
        }
    }
}
