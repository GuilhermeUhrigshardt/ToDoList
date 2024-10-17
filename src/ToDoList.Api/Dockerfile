FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# copy all .csproj files and restore as distinct layers. Use of the same COPY command for every dockerfile in the project to take advantage of docker caching
COPY ToDoList.sln ToDoList.sln
COPY src/ToDoList.Api/ToDoList.Api.csproj src/ToDoList.Api/ToDoList.Api.csproj
COPY src/ToDoList.Application/ToDoList.Application.csproj src/ToDoList.Application/ToDoList.Application.csproj
COPY src/ToDoList.Domain/ToDoList.Domain.csproj src/ToDoList.Domain/ToDoList.Domain.csproj
COPY src/ToDoList.Infrastructure/ToDoList.Infrastructure.csproj src/ToDoList.Infrastructure/ToDoList.Infrastructure.csproj
COPY src/ToDoList.Repository/ToDoList.Repository.csproj src/ToDoList.Repository/ToDoList.Repository.csproj
COPY test/ToDoList.UnitTests/ToDoList.UnitTests.csproj test/ToDoList.UnitTests/ToDoList.UnitTests.csproj
COPY test/ToDoList.IntegrationTests/ToDoList.IntegrationTests.csproj test/ToDoList.IntegrationTests/ToDoList.IntegrationTests.csproj

# Restore package deps
RUN dotnet restore ToDoList.sln

# Copy the app folders over
COPY src src
WORKDIR /app/src/ToDoList.Api
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "ToDoList.Api.dll" ] 