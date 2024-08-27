using System;

namespace ToDoList.Domain.Entities;

public class Item : BaseEntity
{
    public bool Completed { get; set; }
}
