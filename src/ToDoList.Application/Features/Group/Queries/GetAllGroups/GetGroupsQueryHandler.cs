using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetAllGroups;

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupDto>>
{
    public Task<List<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
