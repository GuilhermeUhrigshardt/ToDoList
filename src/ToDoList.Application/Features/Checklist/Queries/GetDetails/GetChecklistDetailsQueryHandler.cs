using System;
using AutoMapper;
using MediatR;
using ToDoList.Application.Contracts.Repository;

namespace ToDoList.Application.Features.Checklist.Queries.GetDetails;

public class GetChecklistDetailsQueryHandler(IMapper mapper, IChecklistRepository repository)
    : IRequestHandler<GetChecklistDetailsQuery, ChecklistDetailsDto>
{
    public async Task<ChecklistDetailsDto> Handle(GetChecklistDetailsQuery request, CancellationToken cancellationToken)
    {
        var checklistDetails = await repository.GetByIdAsync(request.Id);
        return mapper.Map<ChecklistDetailsDto>(checklistDetails);
    }
}
