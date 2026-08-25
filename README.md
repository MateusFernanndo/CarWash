## About the project

**CarWash API** is a REST API built with **.NET 8** following **Clean Architecture** principles, designed to manage car wash services. It allows registering clients, service type, amount charged, payment method/status, and pick-up/delivery dates, all persisted in a **MySQL** database.

The API follows REST conventions with standard HTTP methods and ships with interactive **Swagger** documentation. Business rules are organized into **Use Cases**, keeping controllers thin and each operation independently testable. **AutoMapper** handles object mapping, **FluentValidation** validates incoming requests, and **Entity Framework Core** (via Pomelo) manages database access and migrations.

### Features

- **Clean Architecture**: clear separation between API, Application, Domain, Infrastructure, Communication and Exception layers.
- **Full CRUD**: register, update, get by id, list all and delete car wash services.
- **Automatic migrations**: database schema applied automatically on startup.
- **Localized error messages**: responses in EN, PT-BR, ES, FR and JA via `Accept-Language` header.
- **RESTful API with Swagger**: interactive docs for exploring and testing endpoints.
- **Test coverage**: unit tests (use cases, validators) and integration tests (`WebApplicationFactory`).

### API Endpoints

| Method | Route | Description |
|---|---|---|
| `POST` | `/api/CarService` | Register a new service |
| `PUT` | `/api/CarService/{id}` | Update an existing service |
| `GET` | `/api/CarService/{id}` | Get a service by id |
| `GET` | `/api/CarService` | List all services |
| `DELETE` | `/api/CarService/{id}` | Delete a service |

### Built with

![badge-dot-net]
![badge-csharp]
![badge-mysql]
![badge-efcore]
![badge-swagger]
![badge-xunit]

## Getting Started

### Requirements

- [.NET SDK 8.0+][dot-net-sdk]
- MySQL Server 8.x
- Visual Studio 2022+, Rider or VS Code

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/MateusFernanndo/CarWash.git
    ```
2. Set your connection string in `src/CarWash.Api/appsettings.json`:
    ```json
    "ConnectionStrings": {
      "Connection": "Server=localhost;Database=carwashdb;Uid=root;Pwd=YOUR_PASSWORD;"
    }
    ```
3. Run the API — migrations are applied automatically on startup:
    ```sh
    dotnet run --project src/CarWash.Api
    ```
4. Open `/swagger` to explore the endpoints.

### Running tests

```sh
dotnet test
```

<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET%208-512BD4?logo=dotnet&logoColor=fff&style=flat-square
[badge-csharp]: https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=fff&style=flat-square
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=flat-square
[badge-efcore]: https://img.shields.io/badge/EF%20Core-512BD4?logo=nuget&logoColor=fff&style=flat-square
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=flat-square
[badge-xunit]: https://img.shields.io/badge/xUnit-512BD4?style=flat-square
