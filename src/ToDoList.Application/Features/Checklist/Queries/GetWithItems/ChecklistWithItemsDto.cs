namespace ToDoList.Application.Features.Checklist.Queries.GetWithItems;

public sealed record ChecklistWithItemsDto(Guid Id, string? Name, List<ItemForChecklistWithItemsDto> items);
