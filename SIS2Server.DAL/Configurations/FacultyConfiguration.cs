using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.DAL.Configurations;

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(e => e.FacultySubjects)
            .WithOne(e => e.Faculty)
            .HasForeignKey(e => e.FacultyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Groups)
            .WithOne(e => e.Faculty)
            .HasForeignKey(e => e.FacultyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}