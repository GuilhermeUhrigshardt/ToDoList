using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IItemRepository : IGenericRepository<Item>
{
    Task<List<Item>> GetItemsByChecklistAsync(Guid ChecklistId);
    Task<List<Item>> GetItemsInChecklistAsync(Guid Id);
}
