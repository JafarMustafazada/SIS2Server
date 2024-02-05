using Microsoft.AspNetCore.Identity;

namespace SIS2Server.Core.Entities.UserRelated;

public class AppUser : IdentityUser
{
    public bool IsStudentUser { get; set; } = true;

    // Reletaions //
    public IEnumerable<UserStudent>? UserStudents { get; set; }
    public IEnumerable<UserTeacher>? UserTeachers { get; set; }
}
