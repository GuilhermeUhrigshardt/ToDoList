using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<bool> IsGroupUniqueAsync(string Name);
    Task<Group?> GetGroupWithChecklistsAsync(Guid Id);
    Task<Group?> GetGroupWithChecklistsAndItemsAsync(Guid Id);
}
