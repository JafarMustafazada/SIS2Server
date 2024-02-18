using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class Subject : BaseEntity
{
    public int Name { get; set; }

    // //
    public IEnumerable<FacultySubject>? FacultySubjects { get; set; }
    public IEnumerable<TeacherSubject>? TeacherSubjects { get; set; }
}
