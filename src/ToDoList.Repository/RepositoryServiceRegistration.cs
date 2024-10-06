using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Contracts;
using ToDoList.Repository.DatabaseContext;
using ToDoList.Repository.Repositories;

namespace ToDoList.Repository;

public static class RepositoryServiceRegistration
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("ToDoDatabaseConnectionString"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGroupRepository, GroupRepository>();

        return services;
    }
}
