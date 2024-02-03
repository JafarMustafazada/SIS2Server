namespace SIS2Server.Core.Entities.UserRelated;

public class UserStudent
{
    public int StudentId { get; set; }
    public string AppUserId { get; set; }

    // //
    public Student? Student { get; set; }
    public AppUser? AppUser { get; set; }
}
