using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Item.Commands.Update;

public class UpdateItemCommandHandler(IMapper mapper, IItemRepository itemRepository) : IRequestHandler<UpdateItemCommand, Guid>
{
    private readonly IMapper _mapper = mapper;
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<Guid> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var itemToUpdate = _mapper.Map<Domain.Entities.Item>(request.Item);
        var updatedItem = await _itemRepository.UpdateAsync(itemToUpdate) ?? throw new NotUpdatedException(nameof(Domain.Entities.Item), request.Item.Id);
        return updatedItem.Id;
    }
}
