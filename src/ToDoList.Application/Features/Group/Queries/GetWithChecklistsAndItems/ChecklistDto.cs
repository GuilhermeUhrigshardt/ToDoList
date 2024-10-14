namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public record class ChecklistDto(Guid Id, string Name, List<ItemDto> Items);
