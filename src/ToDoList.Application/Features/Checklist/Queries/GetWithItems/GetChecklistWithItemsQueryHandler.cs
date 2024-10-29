using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Application.Exceptions;

namespace ToDoList.Application.Features.Checklist.Queries.GetWithItems;

public class GetChecklistWithItemsQueryHandler(IMapper mapper, IChecklistRepository checklistRepository) : IRequestHandler<GetChecklistWithItemsQuery, ChecklistWithItemsDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChecklistRepository _checklistRepository = checklistRepository;

    public async Task<ChecklistWithItemsDto> Handle(GetChecklistWithItemsQuery request, CancellationToken cancellationToken)
    {
        var checklist = await _checklistRepository.GetChecklistWithItemsAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.Entities.Checklist), request.Id);
        return _mapper.Map<ChecklistWithItemsDto>(checklist);
    }
}
