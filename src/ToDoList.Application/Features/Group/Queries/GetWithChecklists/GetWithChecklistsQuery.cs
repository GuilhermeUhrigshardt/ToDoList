using MediatR;

namespace ToDoList.Application.Features.Group.Queries.GetWithChecklists;

public sealed record GetWithChecklistsCommand(Guid Id) : IRequest<GroupWithChecklistsDto>;
