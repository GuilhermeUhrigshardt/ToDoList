using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts;
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
}
