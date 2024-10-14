using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Repository.DatabaseContext;

namespace ToDoList.Repository.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ToDoDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsGroupUniqueAsync(string name)
    {
        return ! await _context.Groups.AnyAsync(x => x.Name == name);
    }

    public async Task<Group?> GetGroupWithChecklists(Guid Id)
    {
        return await _context.Groups.Where(p => p.Id == Id).Include(p => p.Checklists).FirstOrDefaultAsync();
    }

    public async Task<Group?> GetGroupWithChecklistsAndItems(Guid Id)
    {
        return await _context.Groups.Where(p => p.Id == Id).Include(p => p.Checklists!).ThenInclude(p => p.Items).FirstOrDefaultAsync();
    }
}
