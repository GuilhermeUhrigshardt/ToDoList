namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public record class GroupWithChecklistsAndItemsDto(Guid Id, string Name, List<ChecklistDto> Checklists);
