using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class TeacherGroup : BaseEntity
{
    public int TeacherId { get; set; }
    public int GroupId { get; set; }

    // //
    public Teacher? Teacher { get; set; }
    public Group? Group { get; set; }
}
