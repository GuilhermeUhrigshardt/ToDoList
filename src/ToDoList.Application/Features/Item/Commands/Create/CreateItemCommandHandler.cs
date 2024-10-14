using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Item.Commands.Create;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;

    public CreateItemCommandHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
            throw new BadRequestException($"Invalid Item", validationResult);

        var requestToCreate = _mapper.Map<Domain.Entities.Item>(request.Item);

        if (requestToCreate.Order == 0)
            requestToCreate.Order = await _itemRepository.GetNextOrderAsync(request.Item.ChecklistId);

        var requestCreated = await _itemRepository.CreateAsync(requestToCreate);
        return requestCreated.Id;
    }
}
