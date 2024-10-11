using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Update;

public sealed record UpdateGroupCommand(GroupUpdateDto Group) : IRequest<Guid>;
