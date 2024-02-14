using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class UserStudent : BaseEntity
{
    public int StudentId { get; set; }
    public string AppUserId { get; set; }

    // //
    public Student? Student { get; set; }
    public AppUser? AppUser { get; set; }
}
