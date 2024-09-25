using System;
using MediatR;

namespace ToDoList.Application.Features.Group.Commands.Create;

public record CreateGroupCommand(string? Name) : IRequest<Guid>;
