using System;
using System.Windows.Input;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Commands.Delete;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Guid>
{
    private readonly IGroupRepository _groupRepository;

    public DeleteGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Guid> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var groupToDelete = await _groupRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Group), request.Id);
        if (!await _groupRepository.DeleteAsync(groupToDelete))
            throw new NotDeletedException(nameof(Group), request.Id);
        return groupToDelete.Id;
    }
}
