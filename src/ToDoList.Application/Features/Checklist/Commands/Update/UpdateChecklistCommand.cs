using MediatR;

namespace ToDoList.Application.Features.Checklist.Commands.Update;

public sealed record UpdateChecklistCommand(ChecklistUpdateDto Checklist) : IRequest<Guid>;
