using System;

namespace ToDoList.Domain.Entities;

public abstract class BaseEntity
{
    protected Guid Id { get; set; }
    protected DateTime? Inserted { get; set; } = DateTime.Now;
}
