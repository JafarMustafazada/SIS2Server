using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.StudentRelated;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class Subject : BaseEntity
{
    public string Name { get; set; }

    // //
    public IEnumerable<FacultySubject>? FacultySubjects { get; set; }
    public IEnumerable<TeacherSubject>? TeacherSubjects { get; set; }
    public IEnumerable<StudentSubjectScore>? StudentSubjectScores { get; set; }
    public IEnumerable<StudentSubjectAttendance>? StudentSubjectAttendances { get; set; }
}
