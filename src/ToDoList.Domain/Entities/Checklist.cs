using System;

namespace ToDoList.Domain.Entities;

public class Checklist : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Item>? Items { get; set; }
    public Group? Group { get; set; }
}
