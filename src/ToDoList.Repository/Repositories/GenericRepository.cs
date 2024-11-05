using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Repository.DatabaseContext;

namespace ToDoList.Repository.Repositories;

public class GenericRepository<T>(ToDoDatabaseContext context) : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ToDoDatabaseContext _context = context;

    public async Task<T> CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
