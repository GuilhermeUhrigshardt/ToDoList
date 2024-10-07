using System;

namespace ToDoList.Domain.Entities;

public class Item : BaseEntity
{
    public required string Title { get; set; }
    public string? Note { get; set; }
    public DateTime? Remind { get; set; }
    public DateTime? DueTo { get; set; }
    public bool Important { get; set; }
    public bool Completed { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int Order { get; set; }
    public required Checklist Checklist { get; set; }
    public Guid ChecklistId { get; set; }
}
