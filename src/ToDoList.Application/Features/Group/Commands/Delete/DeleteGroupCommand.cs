using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Delete;

public record DeleteGroupCommand(Guid Id) : IRequest<Guid>;
