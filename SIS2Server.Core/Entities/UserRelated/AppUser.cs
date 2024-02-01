using Microsoft.AspNetCore.Identity;

namespace SIS2Server.Core.Entities.UserRelated;

public class AppUser : IdentityUser
{
    // Reletaions //
    public IEnumerable<Student>? Students { get; set; }
}
