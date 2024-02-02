using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;
using System.Reflection;

namespace SIS2Server.DAL.Contexts;

public class SIS02DbContext : IdentityDbContext<AppUser>
{
    public SIS02DbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }

    // //
    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    var entries = ChangeTracker.Entries<BaseEntity>();
    //    foreach (var entry in entries)
    //    {
    //        if (entry.State == EntityState.Added)
    //            entry.Entity.CreatedAt = DateTime.UtcNow;
    //    }
    //    return base.SaveChangesAsync(cancellationToken);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
