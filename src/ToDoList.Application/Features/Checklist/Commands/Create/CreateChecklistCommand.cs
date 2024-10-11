using MediatR;

namespace ToDoList.Application.Features.Checklist.Commands.Create;

public record CreateChecklistCommand(Guid Id, Guid GroupId, string? Name) : IRequest<Guid>;
