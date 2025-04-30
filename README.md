# User Management API

A .NET Web API project for managing users with CRUD operations, authentication, and logging.

## Features

- ✅ CRUD operations for user management
- ✅ Data validation
- ✅ Logging middleware
- ✅ Authentication middleware
- ✅ Swagger documentation
- ✅ Error handling

## API Endpoints

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get a specific user
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update a user
- `DELETE /api/users/{id}` - Delete a user

## Authentication

All endpoints (except login/register) require authentication with a Bearer token.
For testing purposes, use the token: `valid-token`

## Project Structure

```
UserManagementAPI/
├── Controllers/
│   └── UsersController.cs
├── Models/
│   ├── User.cs
│   └── DTOs/
├── Services/
│   └── UserService.cs
├── Middleware/
│   ├── LoggingMiddleware.cs
│   └── AuthenticationMiddleware.cs
└── Program.cs
```

## Setup

1. Clone the repository
2. Install .NET SDK
3. Install required NuGet packages:
   - Microsoft.AspNetCore.OpenApi
   - Swashbuckle.AspNetCore
4. Run the application

## Technologies Used

- .NET 6.0
- ASP.NET Core Web API
- Swagger/OpenAPI 