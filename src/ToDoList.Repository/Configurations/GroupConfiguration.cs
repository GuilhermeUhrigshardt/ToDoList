using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Repository.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasData(
            new Group
            {
                Id = new Guid(),
                Name = "Shopping",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid(),
                Name = "Work",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid(),
                Name = "School",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid(),
                Name = "Home",
                Inserted = DateTime.Now
            }
        );

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
