using System;
using System.Diagnostics.Contracts;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IChecklistRepository : IGenericRepository<Checklist>
{
    Task<List<Checklist>> GetChecklistsByGroup(Guid GroupId);
    Task<Checklist?> GetChecklistWithItems(Guid Id);
    Task<int> GetNextOrder(Guid Id);
}
