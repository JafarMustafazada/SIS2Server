using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.UserRelated;

public class Student : PersonEntity
{
    public int GroupId { get; set; } 

    // //
    public DateOnly Entered { get; set; }
    public bool Gender { get; set; }
    public string Nationality { get; set; }
    public DateOnly Graduation { get; set; }

    // //
    public Group? Group { get; set; }
    public IEnumerable<UserStudent>? UserStudents { get; set; }
}
