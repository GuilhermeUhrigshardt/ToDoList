using System;
using System.Data;
using FluentValidation;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Item.Commands.Create;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(p => p.Item.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

        RuleFor(p => p.Item.Note)
            .MaximumLength(400).WithMessage("{PropertyName} must not exceed 400 characters");

        RuleFor(p => p.Item.ChecklistId)
            .NotNull().WithMessage("{PropertyName} cannot be null. Item must have a checklist associated with it");

        RuleFor(p => p.Item.DueTo)
            .Must(IsDateInFuture)
            .WithMessage("{PropertyName} cannot be in the past");

        RuleFor(p => p.Item.Remind)
            .Must(IsDateInFuture)
            .WithMessage("{PropertyName} cannot be in the past");

        RuleFor(p => p.Item.CompletedDate)
            .Must(IsDateInFuture)
            .WithMessage("{PropertyName} cannot be in the past");
    }

    private bool IsDateInFuture(DateTime? date)
    {
        if (date != null && DateTime.Now >= date)
            return false;
        return true;
    }
}
