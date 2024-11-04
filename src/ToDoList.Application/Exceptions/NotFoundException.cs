using FluentValidation.Results;
using System;

namespace ToDoList.Application.Exceptions;

public class NotFoundException : Exception
{
    public IDictionary<string, string[]>? ValidationErrors { get; set; }

    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
    {
    }

    public NotFoundException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
}
