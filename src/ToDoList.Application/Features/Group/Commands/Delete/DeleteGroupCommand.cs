using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Delete;

public sealed record DeleteGroupCommand(Guid Id) : IRequest<Guid>;
