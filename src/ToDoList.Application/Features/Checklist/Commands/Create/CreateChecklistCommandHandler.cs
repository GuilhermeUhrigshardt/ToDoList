using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public class CreateChecklistCommandHandler(IMapper mapper, IChecklistRepository checklistRepository, IGroupRepository groupRepository) : IRequestHandler<CreateChecklistCommand, Guid>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChecklistRepository _checklistRepository = checklistRepository;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task<Guid> Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateChecklistCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
            throw new BadRequestException($"Invalid Checklist", validationResult);

        var checklistToCreate = _mapper.Map<Domain.Entities.Checklist>(request.Checklist);
        var createdChecklist = await _checklistRepository.CreateAsync(checklistToCreate);
        return createdChecklist.Id;
    }
}
