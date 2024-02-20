using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.Core.Entities.SubjectRelated;
using System.Reflection;
using SIS2Server.Core.Entities.StudentRelated;

namespace SIS2Server.DAL.Contexts;

public class SIS02DbContext : IdentityDbContext<AppUser>
{
    public SIS02DbContext(DbContextOptions options) : base(options)
    {
    }

    // //
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<UserStudent> UserStudents { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<UserTeacher> UserTeachers { get; set; }
    public DbSet<FamilyReletaion> FamilyReletaions { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }

    // //
    public DbSet<StudentFormerGroup> StudentFormerGroups { get; set; }
    public DbSet<StudentSubjectAttendance> StudentSubjectAttendances { get; set; }
    public DbSet<StudentSubjectScore> StudentSubjectScores { get; set; }


    // //
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<FacultySubject> FacultySubjects { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<TeacherGroup> TeacherGroups { get; set; }

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
