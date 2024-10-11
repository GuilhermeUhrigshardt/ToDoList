using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public class CreateChecklistCommandHandler : IRequestHandler<CreateChecklistCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IChecklistRepository _repository;

    public CreateChecklistCommandHandler(IMapper mapper, IChecklistRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
    {
        // TODO: Validation
        var checklistToCreate = _mapper.Map<Domain.Entities.Checklist>(request);
        await _repository.CreateAsync(checklistToCreate);
        return checklistToCreate.Id;
    }
}
