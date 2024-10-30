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
                Id = new Guid("77084991-731a-4ffb-9151-4630a449ef8a"),
                Name = "Shopping",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid("104f9716-3fa6-436b-9178-facc35469d58"),
                Name = "Work",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid("b1a83dfa-388d-4214-908f-ef6c7cacb2e0"),
                Name = "School",
                Inserted = DateTime.Now
            },
            new Group
            {
                Id = new Guid("fcf89170-a712-4b75-aa39-e354223a73f2"),
                Name = "Home",
                Inserted = DateTime.Now
            }
        );

        builder.Property(x => x.Id)
            .HasColumnName("IdGroup");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
