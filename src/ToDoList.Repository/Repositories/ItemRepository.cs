using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Repository.DatabaseContext;

namespace ToDoList.Repository.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(ToDoDatabaseContext context) : base(context)
    {
    }

    public async Task<List<Item>> GetItemsByChecklistAsync(Guid ChecklistId)
    {
        return await _context.Items.Where(x => x.ChecklistId == ChecklistId).ToListAsync();
    }

    public async Task<List<Item>> GetItemsInChecklistAsync(Guid Id)
    {
        var checklistId = await _context.Items.Where(x => x.Id == Id).Select(x => x.ChecklistId).FirstOrDefaultAsync();
        return await _context.Items.Where(x => x.ChecklistId == checklistId).ToListAsync();
    }

    public async Task<int> GetNextOrderAsync(Guid ChecklistId)
    {
        return await _context.Items.AsNoTracking().Where(x => x.ChecklistId == ChecklistId).Select(x => x.Order).MaxAsync() + 1;
    }
}
