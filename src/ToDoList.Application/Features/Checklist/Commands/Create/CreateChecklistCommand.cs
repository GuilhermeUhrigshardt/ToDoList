using MediatR;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public sealed record CreateChecklistCommand(Guid Id, Guid GroupId, string? Name) : IRequest<Guid>;
