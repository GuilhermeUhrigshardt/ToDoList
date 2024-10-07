using System;
using MediatR;

namespace ToDoList.Application.Features.Item.Commands.Reorder;

public sealed record ReorderItemsCommand(Guid Id, int Order) : IRequest<int>;
