using System;

namespace ToDoList.Domain.Entities;

public abstract class BaseEntity
{
    public bool Active { get; set; } = true;
    public int Version { get; set; } = 1;
    public DateTime? Inserted { get; set; }
    public DateTime? Updated { get; set; }
}
