using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public class GetWithChecklistsAndItemsQueryHandler(IMapper mapper, IGroupRepository groupRepository) : IRequestHandler<GetWithChecklistsAndItemsQuery, GroupWithChecklistsAndItemsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task<GroupWithChecklistsAndItemsDto> Handle(GetWithChecklistsAndItemsQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetGroupWithChecklistsAndItemsAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.Entities.Group), request.Id);
        return _mapper.Map<GroupWithChecklistsAndItemsDto>(group);
    }
}
