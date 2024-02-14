using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class Group : BaseEntity
{
    public int FacultyId { get; set; }

    // //
    public Faculty? Faculty { get; set; }
    public IEnumerable<Student>? Students { get; set; }
}
