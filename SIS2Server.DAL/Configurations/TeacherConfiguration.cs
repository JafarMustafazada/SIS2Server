using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.DAL.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(b => b.Surname)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(b => b.Patronymic)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(b => b.Birthday)
            .IsRequired()
            .HasColumnType("date");

    }
}