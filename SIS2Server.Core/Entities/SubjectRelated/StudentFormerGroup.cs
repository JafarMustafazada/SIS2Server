using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class StudentFormerGroup : BaseEntity
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }

    // //
    public Student? Student { get; set; }
    public Group? Group { get; set; }
}
