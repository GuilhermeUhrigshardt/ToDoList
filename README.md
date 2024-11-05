# ToDoList

## Overview

This project is built using .NET 8 and follows modern software development practices to ensure maintainability, scalability, and testability. It emulates a simple to-do list application with basic CRUD operations for managing tasks and lists.

## Design Patterns

1. Repository Pattern
2. Dependency Injection
3. CQRS (Command Query Responsibility Segregation)
4. Mediator Pattern

## Libraries

1. Entity Framework Core
2. MediatR
3. AutoMapper
4. FluentValidation
5. xUnit
6. Moq
7. Shouldly

## Getting Started

### Prerequisites
- 1. .NET 8 SDK
- 2. Docker

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/GuilhermeUhrigshardt/ToDoList.git
    ```
2. Navigate to the project directory:
    ```bash
    cd ToDoList
    ```

### Running the Application
1. To run the application, use the following command:
    ```bash
    docker compose up
    ```

### Running Tests
1. To run the unit tests, use the following command:
    ```bash
    dotnet test
    ```

## Purpose

This project was created to practice various design patterns, .NET 8 features, and libraries such as Entity Framework Core, MediatR, AutoMapper, FluentValidation, and xUnit. It serves as a practice tool to master how these technologies can be integrated to build a robust and maintainable application.
