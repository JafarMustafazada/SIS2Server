using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class Group
{
    public int FacultyId { get; set; }

    // //
    public Faculty? Faculty { get; set; }
    public IEnumerable<Student>? Students { get; set; }
}
