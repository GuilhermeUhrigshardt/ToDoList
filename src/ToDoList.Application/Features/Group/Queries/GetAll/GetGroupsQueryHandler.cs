using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Group.Queries.GetAll;

public class GetGroupsQueryHandler(IMapper mapper, IGroupRepository groupRepository) : IRequestHandler<GetGroupsQuery, List<GroupDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task<List<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetAllAsync();
        return _mapper.Map<List<GroupDto>>(groups);
    }
}
