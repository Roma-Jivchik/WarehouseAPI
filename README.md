# Warehouse API

The WarehouseAPI project is a .NET web application that uses a SQL Server database for managing a warehouse system. It incorporates JWT authorization for secure authentication and authorization of users. This Readme.md file will provide instructions on how to run the project both without Docker Compose and with Docker Compose.

## Table of Contents
- [Warehouse API](#Warehouse-api)
  - [Table of Contents](#table-of-contents)
  - [Requirements](#requirements)
  - [Setup](#setup)
    - [Without Docker Compose](#without-docker-compose)
      - [Database Setup](#database-setup)
      - [Create Database](#create-database)
      - [Running the Application](#running-the-application)
      - [Accessing the API](#accessing-the-api)
    - [With Docker Compose](#with-docker-compose)
      - [Running the Application](#running-the-application-1)
      - [Accessing the API](#accessing-the-api-1)
  - [Authorization](#authorization)
      - [Login](#login)
      - [Register](#register)

## Requirements
Before running the WarehouseAPI project, ensure you have the following prerequisites installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (need .NET 7)
- [Docker](https://www.docker.com/get-started) (only required for Docker Compose method)
- [SQL Server for Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (to use without Docker)

## Setup

### Without Docker Compose
1. Clone the project repository from GitHub.
2. Navigate to the `API` directory.

#### Database Setup
3. Open `appsettings.json` in the `WarehouseAPI.API` project and update the `ConnectionStrings` section with your SQL Server credentials.

#### Create Database
4. Using SQL Server Management Studio, create an empty database named WarehouseAPIDatabase

#### Running the Application
To run the WarehouseAPI project, follow these steps:

5. Open your terminal or command prompt.

6. Navigate to the project directory `{path to project}\API\WarehouseAPI.API`.

7. Execute the following command: `dotnet run`

Alternatively, you can use Visual Studio to run the project.

#### Accessing the API

Once the WarehouseAPI is running, you can access it through the following URLs:

- API Base URL: http://localhost:5227 (HTTP)
- Swagger Documentation: http://localhost:5227/swagger

### With Docker Compose
1. Clone the project repository from GitHub.
2. Open your terminal or command prompt.
3. Navigate to the docker compose directory `{path to project}\docker-compose`.

#### Running the Application
4.  Run the application using Docker Compose: `docker compose up`

#### Accessing the API

Once the WarehouseAPI is running, you can access it through the following URLs:

- API Base URL: http://localhost:5000 (HTTP)
- Swagger Documentation: http://localhost:5000/swagger

## Authorization
The WarehouseAPI project uses JWT (JSON Web Tokens) for authorization. To perform authorized actions, you must obtain an access token by following the steps below:

#### Login
To obtain an access token for an existing user, use the following endpoint:

- **POST /api/identity/login**: Provide your login and password in the request body to receive an access token.

#### Register
If you are a new user, you can register and receive an access token using the following endpoint:

- **POST /api/identity/register**: Register as a new user to obtain an access token.

With the access token obtained from either the login or register endpoint, include it in the Authorization header of subsequent requests as follows:

`Authorization: Bearer <your_access_token>`