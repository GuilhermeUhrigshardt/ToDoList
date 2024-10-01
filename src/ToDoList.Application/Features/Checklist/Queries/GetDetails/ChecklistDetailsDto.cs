namespace ToDoList.Application.Features.Checklist.Queries.GetDetails;

public record ChecklistDetailsDto(Guid Id, string? Name, DateTime Inserted);
