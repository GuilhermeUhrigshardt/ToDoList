namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public record class ChecklistForGroupWithChecklistsAndItemsDto(Guid Id, string Name, List<ItemForGroupWithChecklistsAndItemsDto> Items);
