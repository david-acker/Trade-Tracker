# TradeTracker
Stock trade and portfolio tracking solution implemented in ASP.NET Core using [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

## Technologies

* [ASP.NET Core 5](https://dotnet.microsoft.com/apps/aspnet)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Serilog](https://serilog.net/)

## Objectives
- [x] CRUD Functionality for Transactions
- [ ] Portfolio Tracking
- [ ] Aggregate Statistics & Summary Data:
  - [ ] By Security
  - [ ] Using Filters/Queries (e.g. time period, labels, include/exclude, etc.) 
- [ ] Pragmatically Adherent to [REST Architecture Constraints](https://restfulapi.net/rest-architectural-constraints/)
- [ ] Basic WebUI with Angular + TypeScript

## Architecture

### Api
* Contains the ASP.NET Core project used to interact with the application through HTTP requests. 

### Application
* Contains custom exceptions, interfaces, models, DTOs, and mapping profiles for the application.
* Includes application features using with the [Command and Query Responsibility Segregation (CQRS)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) pattern.
* Provides an extension method for registering application services with the ASP.NET Core Dependency Injection container.

### Domain
* Contains all domain entities and enums for the application&mdash;created as [plain old CLR objects (POCO)](https://en.wikipedia.org/wiki/Plain_old_CLR_object) with no dependencies on other application layers or external packages.

### Identity
* Contains models, services, and EF Core types for  authentication and authorization with ASP.NET Core Identity.
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

### Infrastructure
* Contains classes for infrastructure-specific services in the application, such as exporting data as a CSV file. 
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

### Persistence
* Contains repositories, services, and EF Core Types for the data access implementation&mdash;currently using SQLite.
* Provides an extension method to register services with the ASP.NET Core Dependency Injection container.

## Motivation
* Learn Clean Architecture application development
* Gain experience with the ASP.NET Core web framework

## License
TradeTracker is licensed under the [MIT license](LICENSE).
