using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class Student : BaseEntity
{
    public string AppUserId { get; set; }

    // //
    public DateOnly Birthday { get; set; }

    // //
    public AppUser? AppUser { get; set; }
}
