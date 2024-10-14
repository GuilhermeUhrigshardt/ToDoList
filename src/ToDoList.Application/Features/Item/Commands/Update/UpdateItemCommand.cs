using MediatR;

namespace ToDoList.Application.Features.Item.Commands.Update;

public sealed record UpdateItemCommand(ItemUpdateDto Item) : IRequest<Guid>;
