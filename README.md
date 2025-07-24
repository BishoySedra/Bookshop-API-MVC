# BookShop API

BookShop API is a web application built with ASP.NET Core 8.0. It provides functionality to manage book categories and serves as a foundation for learning and building modern web applications.

---

## Agenda

This README covers the following topics:

1. [Features](#features)
2. [Project Structure](#project-structure)
3. [Prerequisites](#prerequisites)
4. [Getting Started](#getting-started)
5. [Using Docker for SQL Server](#using-docker-for-sql-server)
6. [Technologies Used](#technologies-used)

---

## Features

- **Book Category Management**: Create, read, update, and delete book categories.
- **API Documentation**: Integrated Swagger UI for API exploration and testing.
- **Database Integration**: Uses Entity Framework Core with SQL Server for data persistence.
- **Custom Middleware**: Includes custom error handling middleware.
- **Responsive Design**: Utilizes Bootstrap for a modern and responsive UI.
- **Docker Support**: Includes a `docker-compose.yml` file for running a SQL Server database container.

---

## Project Structure

- **DataAccess**: Contains the database context and migrations for Entity Framework Core.
- **Models**: Defines entity configurations and domain models.
- **Web**: The main web application with controllers, middleware, views, and static assets.

---

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/) (optional, for running the database container)

---

## Getting Started

### 1. Clone the repository:
```sh
git clone https://github.com/BishoySedra/EVA-Dotnet-Task-1.git
cd EVA-Dotnet-Task-1
```

### 2. Update the connection string in `appsettings.json`:
```json
"ConnectionStrings": {
   "DefaultConnection": "Your-SQL-Server-Connection-String"
}
```

### 3. Apply database migrations:
```sh
cd Web
dotnet ef database update
```

### 4. Run the application:
```sh
dotnet run
```

### 5. Access the application:
- **API Documentation**: `https://localhost:<port>/swagger`
- **Web Interface**: `https://localhost:<port>`

---

## Using Docker for SQL Server

If you prefer to use Docker for the database, a `docker-compose.yml` file is provided in the Web project.

### Steps:
1. Navigate to the Web directory:
   ```sh
   cd Web
   ```

2. Run the following command:
   ```sh
   docker-compose up -d
   ```

3. Update the connection string in `appsettings.json` to:
   ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost,1433;Database=BookShop;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"
   }
   ```

---

## Technologies Used

- **Backend**: ASP.NET Core 8.0
- **Frontend**: Bootstrap, jQuery
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger
- **Containerization**: Docker