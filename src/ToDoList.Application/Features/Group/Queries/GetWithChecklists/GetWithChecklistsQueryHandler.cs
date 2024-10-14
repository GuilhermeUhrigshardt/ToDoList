using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Queries.GetWithChecklists;

public class GetWithChecklistsQueryHandler(IMapper mapper, IGroupRepository groupRepository) : IRequestHandler<GetWithChecklistsQuery, GroupWithChecklistsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task<GroupWithChecklistsDto> Handle(GetWithChecklistsQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetGroupWithChecklistsAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.Entities.Group), request.Id);
        return _mapper.Map<GroupWithChecklistsDto>(group);
    }
}
