using MediatR;

namespace ToDoList.Application.Features.Checklist.Commands.Delete;

public sealed record DeleteChecklistCommand(Guid Id) : IRequest<Guid>;
