using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Checklist.Queries.GetAll;

public class GetChecklistsQueryHandler : IRequestHandler<GetChecklistsQuery, List<ChecklistDto>>
{
    private readonly IMapper _mapper;
    private readonly IChecklistRepository _repository;

    public GetChecklistsQueryHandler(IMapper mapper, IChecklistRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ChecklistDto>> Handle(GetChecklistsQuery request, CancellationToken cancellationToken)
    {
        var checklists = await _repository.GetChecklistsByGroupAsync(request.GroupId);
        return _mapper.Map<List<ChecklistDto>>(checklists);
    }
}
