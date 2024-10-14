using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<bool> IsGroupUniqueAsync(string Name);
    Task<Group?> GetGroupWithChecklists(Guid Id);
    Task<Group?> GetGroupWithChecklistsAndItems(Guid Id);
}
