using System;
using FluentValidation.Results;

namespace ToDoList.Application.Exceptions;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]>? ValidationErrors { get; set; }

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
}
