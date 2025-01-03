using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Repository.DatabaseContext;
using ToDoList.Repository.Repositories;

namespace ToDoList.Repository;

public static class RepositoryServiceRegistration
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var context = serviceProvider.GetRequiredService<ToDoDatabaseContext>();
            var pendingMigrations = context.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                context.Database.Migrate();
            }
        }

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IChecklistRepository, ChecklistRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}
