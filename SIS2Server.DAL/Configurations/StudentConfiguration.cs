using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.Core.Extensions;

namespace SIS2Server.DAL.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ConfigurePerson();

        builder.Property(e => e.GotInAt)
            .IsRequired()
            .HasColumnType("date");

        builder.HasOne(e => e.Group)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.UserStudents)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
