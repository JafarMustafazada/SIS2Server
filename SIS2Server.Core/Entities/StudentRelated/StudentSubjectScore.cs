using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.StudentRelated;

public class StudentSubjectScore : StudentRealtionBase
{
    public int SubjectId { get; set; }

    public int LabScore { get; set; } = 0;
    public int LecScore { get; set; } = 0;
    public int ExamScore { get; set; } = 0;

    // //
    public Subject? Subject { get; set; }
}
