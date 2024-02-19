using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.StudentRelated;

public class StudentSubjectAttendance : StudentRealtionBase
{
    public int SubjectId { get; set; }

    public int HoursSkipped { get; set; } = 0;

    // //
    public Subject? Subject { get; set; }
}
