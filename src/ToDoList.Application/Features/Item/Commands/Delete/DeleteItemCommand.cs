using MediatR;

namespace ToDoList.Application.Features.Item.Commands.Delete;

public sealed record DeleteItemCommand(Guid Id) : IRequest<Guid>;
