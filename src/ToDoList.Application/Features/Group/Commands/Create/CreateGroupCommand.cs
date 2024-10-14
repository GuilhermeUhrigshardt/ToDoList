using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Create;

public sealed record CreateGroupCommand(GroupCreateDto Group) : IRequest<Guid>;
