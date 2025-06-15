# 🛒 eShop Microservices

This e-commerce platform is built using modular microservices—**Catalog**, **Basket**, **Discount**, and **Ordering**—each focused on a specific business function.

It combines:
- **NoSQL and relational databases** (Marten with PostgreSQL, Redis, SQL Server)
- **Event-driven communication** via RabbitMQ
- **gRPC** for high-performance inter-service calls
- **Carter** for minimal RESTful APIs
- **YARP API Gateway** for centralized routing and cross-cutting concerns

![Architecture](https://github.com/user-attachments/assets/34ddcaf2-2ca4-4b6e-8834-dceeb0d3988b)

---

## 🧱 Architecture Overview

| **Architectures**            | **Patterns & Principles**                      | **Databases**                 | **Libraries**                            |
|-----------------------------|-----------------------------------------------|-------------------------------|------------------------------------------|
| Layered Architecture        | SOLID, DI                                     | Transactional Document DB     | Carter                                   |
| Vertical Slice Architecture | CQRS                                          | PostgreSQL                    | Marten                                   |
| Domain-Driven Design (DDD)  | Mediator, Proxy, Decorator, Options           | Redis                         | MediatR                                  |
| Clean Architecture          | Pub/Sub, Caching                              | SQLite                        | Mapster                                  |
|                             | API Gateway                                   | SQL Server                    | MassTransit, FluentValidation, EF Core, Refit |

---

## 🐳 Containerization and Orchestration

- Dockerfiles and Docker Compose to containerize and orchestrate services.

---

## 🚪 API Gateway and Client

- **YARP API Gateway**: Acts as a reverse proxy for backend services.
- **Shopping.Web**: Consumes APIs using the Refit REST client.

---

## 🔁 Communication Patterns

- **Synchronous:** gRPC for high-performance service-to-service calls
- **Asynchronous:** RabbitMQ with MassTransit (Pub/Sub)

---

## 📦 Catalog Service

- **Purpose**: Manages product data and categories
- **Architecture**:
  - Vertical Slice + REST API
  - Stateless service using Marten + PostgreSQL
  - Implements CQRS with MediatR
- **Key Technologies**:
  - .NET 8, C# 12
  - Carter, Marten, PostgreSQL
  - MediatR, FluentValidation
  - HealthChecks, Custom Exception Middleware
  - ASP.NET Core DI

---

## 💸 Discount Service

- **Purpose**: Manages discount coupons
- **Architecture**:
  - Layered + gRPC
  - Stateless and uses Protobuf for serialization
- **Key Technologies**:
  - .NET 8, C# 12
  - ASP.NET Core + gRPC
  - EF Core + PostgreSQL
  - Mapster, HealthChecks
  - Exception Middleware, ASP.NET Core DI

---

## 🧺 Basket Service

- **Purpose**: Manages user shopping carts
- **Architecture**:
  - Layered + REST API
  - Redis for fast storage, Marten for persistence
  - CQRS, with communication to Discount via gRPC
- **Key Technologies**:
  - .NET 8, C# 12
  - ASP.NET Core + Carter
  - StackExchange.Redis, Marten, PostgreSQL
  - MediatR, FluentValidation, Scrutor
  - MassTransit, HealthChecks
  - ASP.NET Core DI, Exception Middleware

---

## 📑 Ordering Service

- **Purpose**: Manages order placement and history
- **Architecture**:
  - Clean Architecture (Domain, Application, Infra, API)
  - REST API, Stateless, CQRS
  - Publishes events via MassTransit
- **Key Technologies**:
  - .NET 8, C# 12
  - ASP.NET Core, Marten, PostgreSQL
  - MediatR, FluentValidation
  - MassTransit, gRPC
  - HealthChecks, ASP.NET Core DI, Exception Middleware

---

## 🧭 YARP API Gateway

- **Purpose**: Routes external traffic to internal services
- **Architecture**:
  - Stateless reverse proxy
  - Centralized cross-cutting concerns (auth, logging, rate-limiting)
  - Configurable routing
- **Key Technologies**:
  - .NET 8, C# 12
  - ASP.NET Core + YARP
  - Configuration Providers, HealthChecks
  - ASP.NET Core DI

---

## 🖥️ Web (Razor Pages Frontend)

- **Purpose**: Provides user interface for shopping, checkout, and order management
- **Architecture**:
  - Razor Pages (ASP.NET Core)
  - Communicates with microservices using Refit + gRPC
  - Supports authentication and validation
- **Key Technologies**:
  - .NET 8, C# 12
  - Razor Pages, Refit, gRPC Client
  - Bootstrap, jQuery
  - ASP.NET Core DI

---

## ✅ Summary

This microservices platform demonstrates:
- Scalable service separation
- Best practices in .NET 8 + C# 12
- Modern patterns like CQRS, gRPC, and Event-Driven Architecture
- Strong DevOps support through Docker and HealthChecks
- A clean and intuitive frontend using Razor Pages and REST/gRPC integration
