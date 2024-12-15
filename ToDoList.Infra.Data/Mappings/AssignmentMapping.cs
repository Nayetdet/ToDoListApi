using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infra.Data.Mappings;

public class AssignmentMapping : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.AssignmentListId)
            .IsRequired(false);

        builder.Property(x => x.Deadline)
            .IsRequired(false);

        builder.Property(x => x.Concluded)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(x => x.ConcludedAt)
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate();
    }
}