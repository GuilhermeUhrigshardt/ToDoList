using System;

namespace ToDoList.Application.Contracts.Logger;

public interface IApplicationLogger<T>
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(Exception exception, string message);
}
