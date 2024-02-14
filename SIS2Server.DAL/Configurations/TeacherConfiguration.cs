using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.Core.Extensions;

namespace SIS2Server.DAL.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ConfigurePerson();

        builder.Property(e => e.Salary)
            .IsRequired()
            .HasColumnType("DECIMAL(19,4)");
        builder.Property(e => e.Proficiency)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(e => e.Entered)
            .IsRequired()
            .HasColumnType("date"); 
        builder.Property(e => e.Expiration)
            .IsRequired()
            .HasColumnType("date");

        builder.HasMany(e => e.UserTeachers)
            .WithOne(e => e.Teacher)
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}