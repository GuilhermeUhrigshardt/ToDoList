using MediatR;

namespace ToDoList.Application.Features.Item.Commands.Create;

public sealed record CreateItemCommand(ItemCreateDto Item) : IRequest<Guid>;
