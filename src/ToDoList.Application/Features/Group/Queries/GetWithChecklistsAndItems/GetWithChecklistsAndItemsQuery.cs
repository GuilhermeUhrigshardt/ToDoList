using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public sealed record GetWithChecklistsAndItemsQuery(Guid Id) : IRequest<GroupWithChecklistsAndItemsDto>;
