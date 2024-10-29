using MediatR;

namespace ToDoList.Application.Features.Checklist.Queries.GetWithItems;

public sealed record GetChecklistWithItemsQuery(Guid Id) : IRequest<ChecklistWithItemsDto>;
