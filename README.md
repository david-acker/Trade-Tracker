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

## Objectives
- [x] CRUD Functionality for Transactions
  - [X] By security/ticker
  - [X] Using filters/queries (e.g. time range, include/exclude, etc.) 
- [X] Position Tracking
- [ ] Portfolio Tracking
- [ ] Aggregate Statistics & Summary Data:
  - [ ] By security/ticker
  - [ ] Using filters/queries (e.g. time range, include/exclude, etc.) 
- [ ] API (pragmatically) adherent to [REST Architectural Constraints](https://restfulapi.net/rest-architectural-constraints/)
- [ ] Basic UI with Angular + TypeScript

## Architecture

### Api
* Contains the ASP.NET Core project for interacting with the application through HTTP requests. 

### Application
* Contains custom exceptions, interfaces, models, DTOs, and mapping profiles for the application.
* Includes features using with the [Command and Query Responsibility Segregation (CQRS)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) pattern.
* Provides an extension method for registering application services with the ASP.NET Core Dependency Injection container.

### Domain
* Contains all domain entities and enums for the application&mdash;created as [plain old CLR objects (POCO)](https://en.wikipedia.org/wiki/Plain_old_CLR_object) with no dependencies on other application layers or external packages.

### Identity
* Contains models, services, and EF Core types for authentication and authorization with ASP.NET Core Identity.
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

### Infrastructure
* Contains classes for infrastructure-specific services in the application, such as exporting data as a CSV file. 
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

### Persistence
* Contains repositories, services, and EF Core types for the data access implementation&mdash;currently using SQLite.
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

## Motivation
* Learn Clean Architecture application development.
* Gain experience with ASP.NET Core.

## License
TradeTracker is licensed under the [MIT license](LICENSE).
