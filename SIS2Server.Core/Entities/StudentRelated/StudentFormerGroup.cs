using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.StudentRelated;

public class StudentFormerGroup : StudentRealtionBase
{
    public int GroupId { get; set; }

    // //
    public Group? Group { get; set; }
}
