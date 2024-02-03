using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class Teacher : PersonEntity
{
    public string Proficiency { get; set; }
    public decimal Salary { get; set; }
    public DateOnly GotInAt { get; set; }

    // //
    public IEnumerable<UserTeacher>? UserTeachers { get; set; }
}
