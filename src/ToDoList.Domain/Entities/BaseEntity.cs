using System;

namespace ToDoList.Domain.Entities;

public abstract class BaseEntity
{
    protected Guid Id { get; set; }
    protected bool Active { get; set; } = true;
    protected int Version { get; set; } = 1;
    protected DateTime? Inserted { get; set; } = DateTime.Now;
    protected DateTime? Updated { get; set; }
}
