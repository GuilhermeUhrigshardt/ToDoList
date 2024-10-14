using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public class CreateChecklistCommandHandler : IRequestHandler<CreateChecklistCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IChecklistRepository _checklistRepository;

    public CreateChecklistCommandHandler(IMapper mapper, IChecklistRepository checklistRepository)
    {
        _mapper = mapper;
        _checklistRepository = checklistRepository;
    }

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
