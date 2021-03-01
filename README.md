# TradeTracker
TradeTracker is portfolio and trade tracking solution implemented in ASP.NET Core using [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

## Goals
- [x] CRUD Functionality for Transactions
- [ ] Portfolio Tracking
- [ ] Aggregate Statistics & Summary Data:
  - [ ] By Security
  - [ ] Using Filters/Queries (e.g. time period, labels, include/exclude, etc.) 
- [ ] Pragmatically Adherent to REST Architecture Contraints
- [ ] Basic WebUI with Angular + TypeScript

## Technologies

* [ASP.NET Core 5](https://dotnet.microsoft.com/apps/aspnet)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Serilog](https://serilog.net/)

## Architecture

### API

### TradeTracker.Api

* Contains the ASP.NET Core API used to interact with the application through HTTP requests. 
* Currently not adherent to the [REST architectural constraints](https://restfulapi.net/rest-architectural-constraints/).

### Core

#### TradeTracker.Application

* Contains custom exceptions, interfaces, models, DTOs, and mapping profiles for the application.
* Includes application features using with the [Command and Query Responsibility Segregation (CQRS)](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) pattern.
* Provides an extension method for registering application services with the ASP.NET Core Dependency Injection container.

#### TradeTracker.Domain

* Contains all domain entities and enums for the application&mdash;created as [plain old CLR objects (POCO)](https://en.wikipedia.org/wiki/Plain_old_CLR_object) with no dependencies on other application layers or external packages. 

### Infrastructure

#### TradeTracker.Identity

* Contains models, services, and EF Core types (IdentityDbContext, Migrations) for providing authentication and authorization functionality with ASP.NET Core Identity.
* Provides an extension method for registering identity services with the ASP.NET Core Dependency Injection container.

#### TradeTracker.Infrastructure

* Contains classes for infrastructure-specific services in the application, such as exporting data as a CSV file. 
* Provides an extension method for registering shared infrastructure services with the ASP.NET Core Dependency Injection container.

#### TradeTracker.Persistence

* Contains repositories, services, and EF Core Types (DbContext, Migrations) for the data access implementation&mdash;currently using SQLite.
* Provides an extension method for registering persistence services with the ASP.NET Core Dependency Injection container.

## Motivation

* Learn Clean Architecture application development
* Gain experience with the ASP.NET Core web framework
* Use TradeTracker for my own own stock trades and portfolio

## License
TradeTracker is licensed under the [MIT license](LICENSE).
