using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Checklist.Queries.GetDetails;

public class GetChecklistDetailsQueryHandler : IRequestHandler<GetChecklistDetailsQuery, ChecklistDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IChecklistRepository _repository;

    public GetChecklistDetailsQueryHandler(IMapper mapper, IChecklistRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ChecklistDetailsDto> Handle(GetChecklistDetailsQuery request, CancellationToken cancellationToken)
    {
        var checklistDetails = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<ChecklistDetailsDto>(checklistDetails);
    }
}
