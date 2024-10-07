using MediatR;

namespace ToDoList.Application.Features.Checklist.Queries.GetAll;

public sealed record GetChecklistsQuery(Guid GroupId) : IRequest<List<ChecklistDto>>;
