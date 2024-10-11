using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Commands.Update;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public UpdateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task<Guid> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var groupToUpdate = _mapper.Map<Domain.Entities.Group>(request.Group);
        var updatedGroup = await _groupRepository.UpdateAsync(groupToUpdate) ?? throw new NotUpdatedException(nameof(Domain.Entities.Group), request.Group.Id);
        return updatedGroup.Id;
    }
}
