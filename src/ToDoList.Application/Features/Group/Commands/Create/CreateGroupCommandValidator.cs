using System;
using FluentValidation;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Group.Commands.Create;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandValidator(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

        RuleFor(p => p)
            .MustAsync(GroupNameUnique)
            .WithMessage("Group already exists");
    }

    private Task<bool> GroupNameUnique(CreateGroupCommand command, CancellationToken token)
    {
        return _groupRepository.IsGroupUniqueAsync(command.Name);
    }
}
