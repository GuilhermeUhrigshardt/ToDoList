using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Repository.Configurations;

public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Checklist> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("IdChecklist");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}