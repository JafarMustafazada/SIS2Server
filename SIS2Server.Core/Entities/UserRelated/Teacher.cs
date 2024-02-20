using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.UserRelated;

public class Teacher : PersonEntity
{
    public string Proficiency { get; set; }
    public decimal Salary { get; set; }
    public DateTime Entered { get; set; }
    public DateTime Expiration { get; set; }

    // //
    public IEnumerable<UserTeacher>? UserTeachers { get; set; }
    public IEnumerable<TeacherSubject>? TeacherSubjects { get; set; }
    public IEnumerable<TeacherGroup>? TeacherGroups { get; set; }
}
