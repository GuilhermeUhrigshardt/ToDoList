using MediatR;

namespace ToDoList.Application.Features.Checklist.Queries.GetAll;

public record GetChecklistsQuery(Guid GroupId) : IRequest<List<ChecklistDto>>;
