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
        builder.Property(e => e.Birthday)
            .IsRequired()
            .HasColumnType("date");
    }

    // //
}
