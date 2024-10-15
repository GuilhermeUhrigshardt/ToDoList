using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ToDoList.Application.Contracts.Logger;
using ToDoList.Infrastructure.Logger;

namespace ToDoList.Infrastructure;

public static class InfrastructureServicesResgistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureLog(configuration);

        services.AddLogging(loggingBuilder => {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        services.AddScoped(typeof(IApplicationLogger<>), typeof(ApplicationLogger<>));

        return services;
    }

    private static void ConfigureLog(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
    }
}
