# TradeTracker
Stock trade and portfolio tracking solution implemented in ASP.NET Core. Generally follows the principles of [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

## Technologies
* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
* [AutoMapper](https://automapper.org/)
* [Dapper](https://github.com/DapperLib/Dapper)
* [SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
* [xUnit](https://xunit.net/)
* [Moq](https://github.com/moq/moq)
* [Autofac](https://github.com/autofac/Autofac)
* [Postman](https://www.postman.com/) (for testing API endpoints)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)

## Documentation

The API documentation using Swagger UI can be viewed here: [API Documentation](https://david-acker.github.io/Trade-Tracker-API-Spec/#/)

## Architecture

### Core
* TradeTracker.Core
### Business
* TradeTracker.Business
### Api
* TradeTracker.Api
### Database
* TradeTracker.Database
* TradeTracker.EntityModels
* TradeTracker.Repository
### Test
* TradeTracker.Api.Test
* TradeTracker.Business.Test
* TradeTracker.Repository.Test

## Motivations
* Learn the basics of application development using Clean Architecture principles.
* Gain experience using ASP.NET Core to build RESTful APIs.

## License
TradeTracker is licensed under the [MIT License](LICENSE).
