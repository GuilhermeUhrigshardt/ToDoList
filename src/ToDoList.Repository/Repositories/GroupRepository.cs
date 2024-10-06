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

    public async Task<bool> IsGroupUnique(string name)
    {
        return ! await _context.Groups.AnyAsync(x => x.Name == name);
    }
}
