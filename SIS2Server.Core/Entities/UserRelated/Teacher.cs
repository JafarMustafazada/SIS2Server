using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class Teacher : PersonEntity
{
    public string AppUserId { get; set; }

    // //


    // //
    public AppUser? AppUser { get; set; }
}
