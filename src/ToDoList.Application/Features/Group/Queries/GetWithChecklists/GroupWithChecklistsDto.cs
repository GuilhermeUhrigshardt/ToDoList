namespace ToDoList.Application.Features.Group.Queries.GetWithChecklists;

public sealed record GroupWithChecklistsDto(Guid Id, string Name, List<ChecklistForGroupWithChecklistsDto> Checklists);
