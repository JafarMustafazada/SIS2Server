using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS2Server.Core.Common;

namespace SIS2Server.Core.Extensions;

public static class PropertyBuilderExtensions
{
    public static void ConfigurePerson<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : PersonEntity
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(e => e.Surname)
            .IsRequired()
            .HasMaxLength(32);
        builder.Property(e => e.Patronymic)
            .IsRequired()
            .HasMaxLength(32);           
        builder.Property(e => e.PlaceOfLiving)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(e => e.Birthday)
            .IsRequired()
            .HasColumnType("date");
    }


    //    builder.HasOne(e => e.Group)
    //        .WithMany(e => e.Students)
    //        .HasForeignKey(e => e.GroupId)
    //        .OnDelete(DeleteBehavior.NoAction);
    //    builder.HasMany(e => e.UserStudents)
    //        .WithOne(e => e.Student)
    //        .HasForeignKey(e => e.StudentId)
    //        .OnDelete(DeleteBehavior.NoAction);
    // 
    //public static void HasOneWithMany<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
    //{
    //}
    //public static void HasManyWithOne<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
    //{
    //}
}
