namespace ToDoList.Application.Features.Item.Commands.Create;

public sealed record ItemCreateDto(string Title, string? Note, DateTime? Remind, DateTime? DueTo, bool Important, bool Completed, DateTime? CompletedDate, int Order, Guid ChecklistId);
