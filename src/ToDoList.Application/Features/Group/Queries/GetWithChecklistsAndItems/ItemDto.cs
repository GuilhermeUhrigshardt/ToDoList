namespace ToDoList.Application.Features.Group.Queries.GetWithChecklistsAndItems;

public sealed record ItemDto(Guid Id, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order);
