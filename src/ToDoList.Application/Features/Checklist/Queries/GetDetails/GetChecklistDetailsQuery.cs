using MediatR;

namespace ToDoList.Application.Features.Checklist.Queries.GetDetails;

public record GetChecklistDetailsQuery(Guid Id) : IRequest<ChecklistDetailsDto>;
