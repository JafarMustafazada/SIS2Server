using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class TeacherSubject : BaseEntity
{
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }

    // //
    public Teacher? Teacher { get; set; }
    public Subject? Subject { get; set; }
}
