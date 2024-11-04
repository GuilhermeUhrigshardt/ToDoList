# ToDo List API

## Overview

This project is built using .NET 8 and follows modern software development practices to ensure maintainability, scalability, and testability. It emulates a simple to-do list application with basic CRUD operations for managing tasks and lists.

## Design Patterns

### 1. Repository Pattern
The Repository Pattern is used to abstract the data access layer, providing a clean separation between the business logic and data access code. This pattern helps in achieving a more testable and maintainable codebase.

### 2. Dependency Injection
Dependency Injection (DI) is used extensively throughout the project to manage dependencies. This allows for better modularity and easier unit testing. The built-in DI container in .NET 8 is utilized for this purpose.

### 3. CQRS (Command Query Responsibility Segregation)
CQRS is used to separate read and write operations. This helps in optimizing performance and scalability by allowing different models for reading and writing data.

## Libraries

### 1. Entity Framework Core
Entity Framework Core is used as the Object-Relational Mapper (ORM) to interact with the database. It simplifies data access by allowing developers to work with data using .NET objects.

### 2. MediatR
MediatR is used to implement the CQRS pattern. It helps in decoupling the sender and receiver of a request, making the code more maintainable and testable.

### 3. AutoMapper
AutoMapper is used to map objects between different layers of the application. This reduces the boilerplate code required for object transformations.

### 4. FluentValidation
FluentValidation is used for validating objects. It provides a fluent interface for building validation rules, making the code more readable and maintainable.

### 5. xUnit
xUnit is used for unit testing. It is a popular testing framework for .NET applications and provides a rich set of features for writing and running tests.

## Getting Started

### Prerequisites
- .NET 8 SDK

### Installation
1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```
2. Navigate to the project directory:
    ```bash
    cd ToDoList
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```

### Installing and Running the Application
To run the application, use the following command:

```bash
docker compose up
```

### Running Tests
To run the unit tests, use the following command:

```bash
dotnet test
```

## Purpose

This project was created to practice various design patterns, .NET 8 features, and libraries such as Entity Framework Core, MediatR, AutoMapper, FluentValidation, and xUnit. It serves as a learning tool to understand how these technologies can be integrated to build a robust and maintainable application.
