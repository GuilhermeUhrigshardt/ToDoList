using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Checklist.Queries.GetAll;

public class GetChecklistsQueryHandler(IMapper mapper, IChecklistRepository repository)
    : IRequestHandler<GetChecklistsQuery, List<ChecklistDto>>
{
    public async Task<List<ChecklistDto>> Handle(GetChecklistsQuery request, CancellationToken cancellationToken)
    {
        var checklists = await repository.GetChecklistsByGroupAsync(request.GroupId);
        return mapper.Map<List<ChecklistDto>>(checklists);
    }
}
