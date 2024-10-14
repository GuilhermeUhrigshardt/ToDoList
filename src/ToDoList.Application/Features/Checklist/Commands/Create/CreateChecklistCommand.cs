using MediatR;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public sealed record CreateChecklistCommand(ChecklistCreateDto Checklist) : IRequest<Guid>;
