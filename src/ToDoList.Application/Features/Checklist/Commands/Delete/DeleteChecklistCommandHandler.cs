using System;
using MediatR;
using ToDoList.Application.Contracts;
using ToDoList.Application.Exceptions;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Features.Checklist.Commands.Delete;

public class DeleteChecklistCommandHandler(IChecklistRepository repository) : IRequestHandler<DeleteChecklistCommand, Guid>
{
    private readonly IChecklistRepository _repository = repository;

    public async Task<Guid> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
    {
        var checklistToDelete = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Checklist), request.Id);
        if (!await _repository.DeleteAsync(checklistToDelete))
            throw new NotDeletedException(nameof(Checklist), request.Id);
        return request.Id;
    }
}
