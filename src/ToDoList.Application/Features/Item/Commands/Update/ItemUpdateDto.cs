namespace ToDoList.Application.Features.Item.Commands.Update;

public sealed record ItemUpdateDto(Guid Id, string Title, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order, Guid ChecklistId);
