using System;
using System.ComponentModel.Design;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
