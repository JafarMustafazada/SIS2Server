using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class FacultySubject : BaseEntity
{
    public int FacultyId { get; set; }
    public int SubjectId { get; set; }

    // //
    public int Semester { get; set; }

    // //
    public Faculty? Faculty { get; set; }
    public Subject? Subject { get; set; }
}
