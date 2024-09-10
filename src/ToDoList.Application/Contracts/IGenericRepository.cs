using System;

namespace ToDoList.Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAllAsync();
    Task<T> GetByIdAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
