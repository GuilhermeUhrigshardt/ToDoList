using System;

namespace ToDoList.Domain.Entities;

public class Group : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Checklist>? Checklists { get; set; }
}
