using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Repository.DatabaseContext;

namespace ToDoList.Repository.Repositories;

public class ChecklistRepository : GenericRepository<Checklist>, IChecklistRepository
{
    public ChecklistRepository(ToDoDatabaseContext context) : base(context)
    {
    }

    public async Task<List<Checklist>> GetChecklistsByGroupAsync(Guid GroupId)
    {
        return await _context.Checklists.Where(x => x.Group != null && x.Group.Id == GroupId).ToListAsync();
    }

    public async Task<Checklist?> GetChecklistWithItemsAsync(Guid Id)
    {
        return await _context.Checklists.Where(x => x.Id == Id).Include(x => x.Items).FirstOrDefaultAsync();
    }
}
