using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Item.Queries.GetByChecklist;

public class GetItemsByChecklistQueryHandler : IRequestHandler<GetItemsByChecklistQuery, List<ItemsByChecklistDto>>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _repository;

    public GetItemsByChecklistQueryHandler(IMapper mapper, IItemRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ItemsByChecklistDto>> Handle(GetItemsByChecklistQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetItemsByChecklistAsync(request.ChecklistId);
        return _mapper.Map<List<ItemsByChecklistDto>>(items);
    }
}
