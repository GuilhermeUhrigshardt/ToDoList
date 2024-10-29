namespace ToDoList.Application.Features.Checklist.Queries.GetWithItems;

public sealed record ItemForChecklistWithItems(Guid Id, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order);
