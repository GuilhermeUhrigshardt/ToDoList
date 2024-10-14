using System;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Item.Commands.Delete;

public class DeleteItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<DeleteItemCommand, Guid>
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<Guid> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var itemToDelete = await _itemRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.Entities.Item), request.Id);
        if (!await _itemRepository.DeleteAsync(itemToDelete))
            throw new NotDeletedException(nameof(Domain.Entities.Item), request.Id);
        return itemToDelete.Id;
    }
}
