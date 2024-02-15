using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.UserRelated;

public class StudentGroupHistory : BaseEntity
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }

    // //
    public Student? Student { get; set; }
    public Group? Group { get; set; }
}
