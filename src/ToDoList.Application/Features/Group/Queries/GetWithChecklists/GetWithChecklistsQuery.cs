using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetWithChecklists;

public sealed record GetWithChecklistsQuery(Guid Id) : IRequest<GroupWithChecklistsDto>;
