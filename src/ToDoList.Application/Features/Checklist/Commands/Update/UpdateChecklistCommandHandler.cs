using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;
using ToDoList.Application.Exceptions;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Checklist.Commands.Update;

public class UpdateChecklistCommandHandler(IMapper mapper, IChecklistRepository repository) : IRequestHandler<UpdateChecklistCommand, Guid>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChecklistRepository _repository = repository;

    public async Task<Guid> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
    {
        var checklistToUpdate = _mapper.Map<Domain.Entities.Checklist>(request.Checklist);
        var updatedChecklist = await _repository.UpdateAsync(checklistToUpdate) ?? throw new NotUpdatedException(nameof(Domain.Entities.Checklist), request.Checklist.Id);
        return updatedChecklist.Id;
    }
}
