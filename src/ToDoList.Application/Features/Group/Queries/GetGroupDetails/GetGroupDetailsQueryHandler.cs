using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Group.Queries.GetGroupDetails;

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, List<GroupDetailDto>>
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public GetGroupDetailsQueryHandler(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    
    public async Task<List<GroupDetailDto>> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var groupDetails = await _groupRepository.GetAllAsync();
        return _mapper.Map<List<GroupDetailDto>>(groupDetails);
    }
}
