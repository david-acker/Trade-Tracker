# TradeTracker
Stock trade and portfolio tracking solution implemented in ASP.NET Core using [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

## Technologies

* [ASP.NET Core 5](https://dotnet.microsoft.com/apps/aspnet)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [Serilog](https://serilog.net/)
* [FluentValidation](https://fluentvalidation.net/)
* [xUnit](https://xunit.net/)
* [Moq](https://github.com/moq/moq)
* [FluentAssertions](https://fluentassertions.com/)
* [AspNetCoreRateLimit](https://github.com/stefanprodan/AspNetCoreRateLimit)
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.WebApi)
* [Postman](https://www.postman.com/) (for testing API endpoints)

## Documentation

The API documentation using Swagger UI can be viewed here: [API Documentation](https://david-acker.github.io/Trade-Tracker-API-Spec/#/)

## Architecture

### Api
* Contains the ASP.NET Core project for interacting with TradeTracker through requests using common HTTP verbs including GET, POST, PUT, PATCH, DELETE, and OPTIONS.
* Implements vendor-specific media types to delineate between the standard JSON representation of a resource and the enriched representation including links for HATEOAS support.

### Application
* Contains custom exceptions, event handlers, interfaces, models, DTOs, validation logic, and mapping profiles for the application.
* Feature code organized using the [Command and Query Responsibility Segregation (CQRS)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) pattern.
* Implements the Mediator pattern, using MediatR, in order to decouple the business logic from the API controllers.
* Provides an extension method for registering application services with the ASP.NET Core Dependency Injection container.

### Domain
* Contains all domain entities, enums, and events for the application&mdash;created as [plain old CLR objects (POCO)](https://en.wikipedia.org/wiki/Plain_old_CLR_object) with no dependencies on other application layers or external packages.

### Identity
* Contains models, services, and EF Core types for JSON Web Token (JWT) authentication and authorization with ASP.NET Core Identity.
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Infrastructure
* Contains classes for infrastructure-specific functionality and services for the implementation of TradeTracker, such as handling the export of transaction data to a CSV file and the dynamic recalculation of affected portfolio positions based transaction-related CRUD activity.
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Persistence
* Contains repositories, services, and EF Core types for the data access implementation&mdash;currently using PostgreSQL with [Npgsql](https://github.com/npgsql/npgsql).
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Web UI
* Contains the TradeTracker single-page application (SPA) built using Angular and TypeScript.

<p align="center">
  <i><b>View Transactions Page</b></i>
</p>

![ViewTransactionsPage](demo/view-transactions-page.png?raw=true "View Transactions Page")

## Motivations
* Learn the basics of application development using Clean Architecture principles.
* Gain experience using ASP.NET Core to build RESTful APIs.

## License
TradeTracker is licensed under the [MIT License](LICENSE).
