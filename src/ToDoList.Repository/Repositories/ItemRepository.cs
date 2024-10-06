using System;
using ToDoList.Application.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Repository.DatabaseContext;

namespace ToDoList.Repository.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(ToDoDatabaseContext context) : base(context)
    {
    }
}
