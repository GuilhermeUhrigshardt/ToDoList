using System;
using System.Data;
using FluentValidation;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public class CreateChecklistCommandValidator : AbstractValidator<CreateChecklistCommand>
{
    public CreateChecklistCommandValidator()
    {
        RuleFor(p => p.Checklist.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
    }
}
