using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.DAL.Configurations;

public class FacultySubjectConfiguration : IEntityTypeConfiguration<FacultySubject>
{
    public void Configure(EntityTypeBuilder<FacultySubject> builder)
    {
        builder.Property(e => e.Semester)
            .IsRequired()
            .HasMaxLength(9);

        //builder.HasOne(e => e.Faculty)
        //    .WithMany(e => e.FacultySubjects)
        //    .HasForeignKey(e => e.FacultyId)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
}
