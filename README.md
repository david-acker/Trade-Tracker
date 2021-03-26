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

## Objectives
- [x] CRUD Functionality for Transactions
  - [X] By security/ticker
  - [X] Using filters/queries (e.g. time range, include/exclude, etc.) 
- [X] Position Tracking By Instrument
  - [x] Average Cost Basis
  - [ ] Profit/Loss (using FIFO)
  - [ ] Aggregate/summary statistics
- [x] API adherent to [REST Architectural Constraints](https://restfulapi.net/rest-architectural-constraints/) *(pragmatically)*
- [ ] Basic UI with Angular + TypeScript
  - [x] Accounts
  - [x] Transactions 
  - [ ] Positions

## Architecture

### Api
* Contains the ASP.NET Core project for interacting with the application through HTTP requests.
* Implement vendor-specific media types for optional HATEOAS support.

### Application
* Contains custom exceptions, event handlers, interfaces, models, DTOs, validation logic, and mapping profiles for the application.
* Includes features using with the [Command and Query Responsibility Segregation (CQRS)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) pattern.
* Provides an extension method for registering application services with the ASP.NET Core Dependency Injection container.

### Domain
* Contains all domain entities, enums, and events for the application&mdash;created as [plain old CLR objects (POCO)](https://en.wikipedia.org/wiki/Plain_old_CLR_object) with no dependencies on other application layers or external packages.

### Identity
* Contains models, services, and EF Core types for JWT Token authentication and authorization with ASP.NET Core Identity.
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Infrastructure
* Contains classes for infrastructure-specific services in the application, such as exporting data as a CSV file.
* Includes services for managing the recalculation of trade positions based on transaction-related CRUD activity.
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Persistence
* Contains repositories, services, and EF Core types for the data access implementation&mdash;currently using SQLite.
* Provides an extension method for registering services with the ASP.NET Core Dependency Injection container.

### Web UI
* Contains the single-page application for TradeTracker built with Angular and TypeScript.

#### View Transactions Page
![ViewTransactionsPage](demo/view-transactions-page.png?raw=true "View Transactions Page")

## Motivations
* Learn the basics of application development using Clean Architecture principles.
* Gain experience using ASP.NET Core to build RESTful APIs.

## License
TradeTracker is licensed under the [MIT license](LICENSE).
