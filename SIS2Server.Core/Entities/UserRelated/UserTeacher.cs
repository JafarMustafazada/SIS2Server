namespace SIS2Server.Core.Entities.UserRelated;

public class UserTeacher
{
    public int TeacherId { get; set; }
    public string AppUserId { get; set; }

    // //
    public AppUser? AppUser { get; set; }
    public Teacher? Teacher { get; set; }
}
