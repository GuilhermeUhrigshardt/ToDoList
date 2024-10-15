using System;
using ToDoList.Application.Contracts.Logger;
using Microsoft.Extensions.Logging;

namespace ToDoList.Infrastructure.Logger;

public class ApplicationLoggerLogger<T>(ILogger<T> logger) : IApplicationLogger<T>
{
    private readonly ILogger<T> _logger = logger;

    public void LogError(Exception exception, string message)
    {
        _logger.LogError(exception, message);
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }
}
