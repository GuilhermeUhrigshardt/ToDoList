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

    public async Task<List<Checklist>> GetChecklistsByGroup(Guid GroupId)
    {
        return await _context.Checklists.Where(x => x.Group != null && x.Group.Id == GroupId).ToListAsync();
    }

    public async Task<Checklist?> GetChecklistWithItems(Guid Id)
    {
        return await _context.Checklists.Where(x => x.Id == Id).Include(x => x.Items).FirstOrDefaultAsync();
    }

    public async Task<int> GetNextOrder(Guid Id)
    {
        return await _context.Items.AsNoTracking().Where(x => x.ChecklistId == Id).Select(x => x.Order).MaxAsync() + 1 ?? 0;
    }
}
