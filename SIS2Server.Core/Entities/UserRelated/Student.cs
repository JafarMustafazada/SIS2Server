using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.UserRelated;

public class Student : PersonEntity
{
    public int GroupId { get; set; }
    public DateOnly GotInAt { get; set; }

    // //
    public Group? Group { get; set; }
    public IEnumerable<UserStudent>? UserStudents { get; set; }
}
