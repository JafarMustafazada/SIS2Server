using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class Student : PersonEntity
{
    public string AppUserId { get; set; }

    // //


    // //
    public AppUser? AppUser { get; set; }
}
