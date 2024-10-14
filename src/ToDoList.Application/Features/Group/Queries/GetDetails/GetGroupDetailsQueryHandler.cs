using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Queries.GetDetails;

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public GetGroupDetailsQueryHandler(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    
    public async Task<GroupDetailsDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Group), request.Id);
        return _mapper.Map<GroupDetailsDto>(group);
    }
}
