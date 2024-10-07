using MediatR;

namespace ToDoList.Application.Features.Checklist.Queries.GetDetails;

public sealed record GetChecklistDetailsQuery(Guid Id) : IRequest<ChecklistDetailsDto>;
