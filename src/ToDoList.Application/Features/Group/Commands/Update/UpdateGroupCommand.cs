using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Update;

public sealed record UpdateGroupCommand(Guid Id, string Name) : IRequest<Guid>;
