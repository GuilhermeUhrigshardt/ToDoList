using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Contracts;

public interface IItemRepository : IGenericRepository<Item>
{
}
