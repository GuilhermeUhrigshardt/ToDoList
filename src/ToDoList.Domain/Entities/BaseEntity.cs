using System;

namespace ToDoList.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime? Inserted { get; set; } = DateTime.Now;
}
