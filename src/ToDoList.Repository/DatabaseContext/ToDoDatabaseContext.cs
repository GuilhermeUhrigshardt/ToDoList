using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Repository.DatabaseContext;

public class ToDoDatabaseContext : DbContext
{
    public ToDoDatabaseContext(DbContextOptions<ToDoDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Checklist> Checklists { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ToDoDatabaseContext).Assembly);

        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added))
        {
            entry.Entity.Id = new Guid();
            entry.Entity.Inserted = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}