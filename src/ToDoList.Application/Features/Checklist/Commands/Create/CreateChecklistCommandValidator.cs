using System;
using System.Data;
using FluentValidation;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public class CreateChecklistCommandValidator : AbstractValidator<CreateChecklistCommand>
{
    private readonly IChecklistRepository _repository;

    public CreateChecklistCommandValidator(IChecklistRepository repository)
    {
        _repository = repository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
    }
}
