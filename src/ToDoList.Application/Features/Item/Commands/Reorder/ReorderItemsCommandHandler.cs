using System;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Item.Commands.Reorder;

public class ReorderItemsCommandHandler(IItemRepository repository) : IRequestHandler<ReorderItemsCommand, int>
{
    private readonly IItemRepository _repository = repository;

    public async Task<int> Handle(ReorderItemsCommand request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetItemsInChecklistAsync(request.Id);

        items.Sort((x, y) => x.Order.CompareTo(y.Order));

        int index = items.FindIndex(x => x.Order == request.Order);
        if (index != -1)
        {
            var newOrder = request.Order;
            for (int i = index; i < items.Count; i++)
            {
                if (items[i].Id == request.Id || items[i].Order > newOrder)
                    break;
                items[i].Order = ++newOrder;
            }
        }

        items.Where(x => x.Id == request.Id).FirstOrDefault()!.Order = request.Order;

        return request.Order;
    }
}
