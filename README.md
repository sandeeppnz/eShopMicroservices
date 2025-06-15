# An e-commerce platform with a microservices architecture

![image](https://github.com/user-attachments/assets/95a6536f-c5dc-46d4-a674-00f238cca3c2)

## Common Technologies

## Catalog Service

The Catalog service is implemented as a microservice and follows a Vertical Slice, RESTful architecture:

- **Microservice:** The Catalog service operates independently, responsible for managing product data and categories.
- **Vertical Slice Architecture:** Organizes code by feature (slice), where each slice contains its own endpoints, handlers, validation, and data access logic, rather than by technical layer.
- **RESTful API:** Exposes endpoints for product operations (CRUD, listing, searching) using HTTP and JSON.
- **Stateless:** The service is stateless; all state is stored in the backing store.
- **CQRS:** Implements Command Query Responsibility Segregation for separating read and write operations.
- **Dependency Injection:** Follows ASP.NET Core DI patterns for service composition.
- **LogBehaviors:** Uses MediatR behaviors for logging requests and responses.
- **ValidatorBehaviors:** Uses FluentValidation for validating commands and queries.
- - **Technologies Used:**  
  - **.NET 8:** The service is built using .NET 8.  
  - **C# 12:** The code uses C# 12 features (e.g., primary constructors, record types).  
  - **Carter:** A minimal API framework for ASP.NET Core, used for routing and endpoint definitions.
  - **Marten:** As the data persistence layer (document database/ORM for PostgreSQL).  
  - **MediatR:** For implementing the mediator pattern and handling commands/queries (CQRS).  
  - **PostgreSQL:** As the primary database, configured via Marten.  
  - **FluentValidation:** For validating models and requests.  
  - **HealthChecks:** For application health monitoring, including PostgreSQL checks.  
  - **Exception Handling Middleware:** Custom exception handler for cross-cutting concerns.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.


## Discount Service

The Discount service is implemented as a microservice and follows a layered, gRPC-based architecture:

- **Microservice:** The Discount service operates independently, responsible for managing discount coupons and related logic.
- **gRPC API:** Exposes endpoints for discount operations (get, create, update, delete) using gRPC for efficient inter-service communication.
- **Layered Structure:**
  - **gRPC Service Layer:** Handles gRPC requests and responses.
  - **Application/Service Layer:** Contains business logic for discount management.
  - **Data Access Layer:** Persists coupon data.
- **DTOs/Protobuf Models:** Uses Protocol Buffers (protobuf) for efficient data serialization and communication.
- **Stateless:** The service is stateless; all state is stored in the backing store.
- **Dependency Injection:** Follows ASP.NET Core DI patterns for service composition.
- **Technologies Used:**  
  - **.NET 8:** The service is built using .NET 8.  
  - **C# 12:** The code uses C# 12 features (e.g., primary constructors, record types).  
  - **ASP.NET Core:** For hosting the gRPC service.  
  - **gRPC:** For high-performance, contract-based inter-service communication.  
  - **Entity Framework Core:** For data access and ORM functionality.  
  - **PostgreSQL:** As the primary database for storing discount data.  
  - **Mapster:** For object mapping between entities and DTOs/protobuf models.  
  - **HealthChecks:** For application health monitoring, including database checks.  
  - **Exception Handling Middleware:** Custom exception handler for cross-cutting concerns.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.

This architecture enables scalability, maintainability, and efficient communication within the Discount service.


## Basket Service

The Basket service is implemented as a microservice and follows a layered, RESTful architecture:

- **Microservice:** The Basket service operates independently, responsible for managing user shopping carts.
- **RESTful API:** Exposes endpoints for basket operations (get, store, delete, checkout) using HTTP and JSON.
- **Layered Structure:**
  - **API Layer:** Handles HTTP requests and responses.
  - **Application/Service Layer:** Contains business logic for basket management.
  - **Data Access Layer:** Persists basket data (commonly in a fast store like Redis).
- **DTOs:** Uses Data Transfer Objects for communication between client and service.
- **Stateless:** The service is stateless; all state is stored in the backing store.
- **Dependency Injection:** Follows ASP.NET Core DI patterns for service composition.
- **Technologies Used:**  
  - **.NET 8:** The service is built using .NET 8, as indicated by the project context.  
  - **C# 12:** The code uses C# 12 features (e.g., primary constructors, record types).  
  - **ASP.NET Core:** For building the web API.  
  - **Carter:** A minimal API framework for ASP.NET Core, used for routing and endpoint definitions.  
  - **MediatR:** For implementing the mediator pattern and handling commands/queries (CQRS).  
  - **FluentValidation:** For validating commands and models.  
  - **Marten:** As the data persistence layer (document database/ORM for PostgreSQL).  
  - **PostgreSQL:** As the primary database, configured via Marten.  
  - **StackExchange.Redis:** For distributed caching using Redis.  
  - **gRPC:** For inter-service communication, specifically to the Discount service.  
  - **MassTransit:** For asynchronous messaging and event-driven communication.  
  - **HealthChecks:** For application health monitoring, including PostgreSQL and Redis checks.  
  - **Exception Handling Middleware:** Custom exception handler for cross-cutting concerns.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.

This architecture enables scalability, maintainability, and clear separation of concerns within the Basket service.

## Ordering Service

The Ordering service is implemented as a microservice and follows a layered, RESTful architecture:

- **Microservice:** The Ordering service operates independently, responsible for managing order processing, status, and history.
- **RESTful API:** Exposes endpoints for order operations (create, update, retrieve, list) using HTTP and JSON.
- **Layered Structure:**
  - **API Layer:** Handles HTTP requests and responses.
  - **Application/Service Layer:** Contains business logic for order management, including validation and orchestration.
  - **Data Access Layer:** Persists order data and manages transactions.
- **DTOs:** Uses Data Transfer Objects for communication between client and service.
- **CQRS:** Implements Command Query Responsibility Segregation for separating read and write operations.
- **Stateless:** The service is stateless; all state is stored in the backing store.
- **Dependency Injection:** Follows ASP.NET Core DI patterns for service composition.
- **Technologies Used:**  
  - **.NET 8:** The service is built using .NET 8.  
  - **C# 12:** The code uses C# 12 features (e.g., primary constructors, record types).  
  - **ASP.NET Core:** For building the web API.  
  - **MediatR:** For implementing the mediator pattern and handling commands/queries (CQRS).  
  - **FluentValidation:** For validating commands and models.  
  - **Marten:** As the data persistence layer (document database/ORM for PostgreSQL).  
  - **PostgreSQL:** As the primary database, configured via Marten.  
  - **MassTransit:** For asynchronous messaging and event-driven communication.  
  - **gRPC:** For inter-service communication (e.g., with Discount service).  
  - **HealthChecks:** For application health monitoring, including PostgreSQL checks.  
  - **Exception Handling Middleware:** Custom exception handler for cross-cutting concerns.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.

This architecture enables scalability, maintainability, and clear separation of concerns within the Ordering service.


## YARP API Gateway

The YARP Gateway is implemented as an API gateway and follows a reverse proxy architecture:

- **API Gateway:** Acts as a single entry point for all client requests, routing them to the appropriate backend microservices.
- **Reverse Proxy:** Forwards HTTP requests to internal services based on routing rules and policies.
- **Centralized Cross-Cutting Concerns:** Handles concerns such as authentication, authorization, logging, and rate limiting at the gateway level.
- **Configuration Driven:** Routing and proxying behavior is defined via configuration files or dynamic configuration providers.
- **Stateless:** The gateway is stateless; it does not store application data.
- **Technologies Used:**  
  - **.NET 8:** The gateway is built using .NET 8.  
  - **C# 12:** The code uses C# 12 features.  
  - **YARP (Yet Another Reverse Proxy):** Microsoft’s reverse proxy library for .NET, providing dynamic routing and load balancing.  
  - **ASP.NET Core:** For hosting the gateway and middleware pipeline.  
  - **HealthChecks:** For monitoring the health of the gateway and downstream services.  
  - **Configuration Providers:** For flexible and dynamic routing configuration.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.

This architecture enables centralized routing, security, and observability for all microservices in the platform.


## Web (Razor Pages Frontend)

The Web project is implemented as a Razor Pages application and serves as the main user interface for the platform:

- **Razor Pages:** Uses ASP.NET Core Razor Pages for building dynamic, server-rendered web pages.
- **UI Layer:** Provides shopping, cart, checkout, and order management experiences for end users.
- **Service-Oriented Integration:** Communicates with backend microservices (Catalog, Basket, Ordering, Discount) via HTTP APIs and gRPC.
- **Dependency Injection:** Uses ASP.NET Core DI for injecting services and configuration.
- **Validation:** Utilizes built-in validation and client-side validation for forms.
- **Authentication & Authorization:** Supports user authentication and role-based access (if configured).
- **Technologies Used:**  
  - **.NET 8:** Built using .NET 8.  
  - **C# 12:** Uses C# 12 features.  
  - **ASP.NET Core Razor Pages:** For server-side web UI.  
  - **Refit:** For type-safe REST API calls to backend services.  
  - **gRPC Client:** For inter-service communication with gRPC-based services.  
  - **Bootstrap & jQuery:** For responsive UI and client-side interactivity.  
  - **Dependency Injection:** Built-in .NET Core DI for service registration and resolution.

This architecture enables a modern, maintainable, and scalable web frontend for the e-commerce platform.
