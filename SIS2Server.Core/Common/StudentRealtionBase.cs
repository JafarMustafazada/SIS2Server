using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.Core.Common;

public class StudentRealtionBase : BaseEntity
{
    public int StudentId { get; set; }

    public Student? Student { get; set; }
}
