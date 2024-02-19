using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.Core.Extensions;

namespace SIS2Server.DAL.Configurations;

public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
{
    public void Configure(EntityTypeBuilder<FamilyMember> builder)
    {
        builder.ConfigurePerson();

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(320);
        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasOne(e => e.Student)
            .WithMany(e => e.FamilyMembers)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.FamilyReletaion)
            .WithMany(e => e.FamilyMembers)
            .HasForeignKey(e => e.FamilyReletaionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
