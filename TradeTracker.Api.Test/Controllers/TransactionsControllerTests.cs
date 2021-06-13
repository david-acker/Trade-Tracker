using Autofac;
using Autofac.Extras.Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TradeTracker.Api.Controllers;
using TradeTracker.Api.Profiles;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Transaction;
using Xunit;

namespace TradeTracker.Api.Test.Controllers
{
    public class TransactionsControllerTests
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
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()))
                    .Returns(() =>
                    {
                        var modelState = new ModelStateDictionary();
                        modelState.AddModelError("Key", "Error Message");
                        return modelState;
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.CreateAsync(new TransactionInputDomainModel());

                Assert.NotNull(response);
                var result = Assert.IsType<UnprocessableEntityObjectResult>(response);
                Assert.Equal(HttpStatusCode.UnprocessableEntity, (HttpStatusCode)result.StatusCode);

                var errors = Assert.IsType<SerializableError>(result.Value);
                Assert.Single(errors);

                var error = errors.SingleOrDefault();
                Assert.Equal("Key", error.Key);
                Assert.Equal("Error Message", ((string[])error.Value).SingleOrDefault());

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionInputDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.IsAny<Transaction>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnTransaction_Create()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.CreateTransaction(It.IsAny<Transaction>()))
                    .ReturnsAsync(new Transaction
                    {
                        TransactionId = 1,
                        Symbol = "AAA"
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.CreateAsync(
                    new TransactionInputDomainModel
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

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionInputDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.IsAny<Transaction>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.CreateTransaction(It.Is<Transaction>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Get()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<Transaction>(null));

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
                        new Transaction
                        {
                            TransactionId = 1,
                            Symbol = "AAA"
                        }));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.GetAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<OkObjectResult>(response);
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);

                var transaction = Assert.IsType<TransactionDomainModel>(result.Value);
                Assert.Equal(1, transaction.TransactionId);
                Assert.Equal("AAA", transaction.Symbol);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Update()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<Transaction>(null));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, new TransactionInputDomainModel());

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()), Times.Never);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<Transaction>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturn422ForInvalidInput_Update()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new Transaction());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()))
                    .Returns(() =>
                    {
                        var modelState = new ModelStateDictionary();
                        modelState.AddModelError("Key", "Error Message");
                        return modelState;
                    });

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, new TransactionInputDomainModel());

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

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionInputDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<Transaction>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnNoContent_Update()
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(_mapper).As<IMapper>()))
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new Transaction
                    {
                        TransactionId = 1,
                        Symbol = "AAA",
                        Quantity = 1,
                        TradePrice = 10
                    });

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()))
                    .Returns(new ModelStateDictionary());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.UpdateTransaction(It.IsAny<Transaction>()))
                    .Returns(Task.CompletedTask);

                var controller = mock.Create<TransactionsController>();

                var response = await controller.UpdateAsync(1, 
                    new TransactionInputDomainModel
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

                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.IsAny<TransactionInputDomainModel>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.ValidateTransaction(It.Is<TransactionInputDomainModel>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.IsAny<Transaction>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.UpdateTransaction(It.Is<Transaction>(i => i != null)), Times.Once);
            }
        }

        [Fact]
        public async Task ItWillReturn404NotFound_Delete()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.FromResult<Transaction>(null));

                var controller = mock.Create<TransactionsController>();

                var response = await controller.DeleteAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<NotFoundObjectResult>(response);
                Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
            }
        }

        [Fact]
        public async Task ItWillReturnNoContent_Delete()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionsService>()
                    .Setup(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .ReturnsAsync(new Transaction());

                mock.Mock<ITransactionsService>()
                    .Setup(x => x.DeleteTransaction(It.IsAny<int>(), It.IsAny<string>()))
                    .Returns(Task.CompletedTask);

                var controller = mock.Create<TransactionsController>();

                var response = await controller.DeleteAsync(1);

                Assert.NotNull(response);
                var result = Assert.IsType<NoContentResult>(response);
                Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)result.StatusCode);

                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.GetTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);

                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
                mock.Mock<ITransactionsService>().Verify(x => x.DeleteTransaction(It.Is<int>(i => i == 1), It.Is<string>(i => i != null)), Times.Once);
            }
        }
    }
}
