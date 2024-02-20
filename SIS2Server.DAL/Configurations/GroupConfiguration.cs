using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.DAL.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.CurrentSemester)
            .IsRequired()
            .HasMaxLength(9);

        builder.HasMany(e => e.Students)
            .WithOne(e => e.Group)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.StudentFormerGroups)
            .WithOne(e => e.Group)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.TeacherGroups)
            .WithOne(e => e.Group)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Faculty)
            .WithMany(e => e.Groups)
            .HasForeignKey(e => e.FacultyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
