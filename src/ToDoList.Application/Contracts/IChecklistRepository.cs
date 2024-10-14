using System;
using System.Diagnostics.Contracts;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IChecklistRepository : IGenericRepository<Checklist>
{
    Task<List<Checklist>> GetChecklistsByGroupAsync(Guid GroupId);
    Task<Checklist?> GetChecklistWithItemsAsync(Guid Id);
}
