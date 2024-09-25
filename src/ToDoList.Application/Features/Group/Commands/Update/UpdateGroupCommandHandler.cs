using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;

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
        var groupToUpdate = _mapper.Map<Domain.Entities.Group>(request);
        await _groupRepository.UpdateAsync(groupToUpdate);
        return groupToUpdate.Id;
    }
}
