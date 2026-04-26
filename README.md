# UserManagementAPI

An ASP.NET Core Web API for managing user records. Built for TechHive Solutions to support HR and IT departments with efficient user administration.

## Features

- Full CRUD operations for user management
- API key authentication
- Input validation with FluentValidation
- Global exception handling with structured error responses
- HTTP request logging

## Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/users` | Retrieve all users |
| GET | `/users/{id}` | Retrieve a user by ID |
| POST | `/users` | Create a new user |
| PUT | `/users/{id}` | Update an existing user |
| DELETE | `/users/{id}` | Delete a user |

## Authentication

All requests require an API key passed in the request header:

```
X-API-KEY: your-api-key
```

Returns `401 Unauthorized` if the key is missing or invalid.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Run the API

```bash
git clone https://github.com/your-username/UserManagementAPI.git
cd UserManagementAPI
dotnet run --project UserManagementAPI
```

The API will be available at `https://localhost:7XXX`. Swagger UI is available in development at `/swagger`.

### Configuration

Set your API key in `appsettings.json`:

```json
{
  "ApiKey": "your-api-key"
}
```

## Tech Stack

- ASP.NET Core 8 (Minimal APIs)
- FluentValidation
- Microsoft.AspNetCore.Diagnostics (global exception handling)
