using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Item.Queries.GetDetails;

public class GetItemDetailsQueryHandler(IMapper mapper, IItemRepository repository) : IRequestHandler<GetItemDetailsQuery, ItemDetailsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly IItemRepository _repository = repository;

    public async Task<ItemDetailsDto> Handle(GetItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Item), request.Id);
        return _mapper.Map<ItemDetailsDto>(item);
    }
}
