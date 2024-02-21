using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.StudentRelated;

namespace SIS2Server.BLL.DTO.SubjectDTO;

public class SubjectScoreDto : IBaseDto<StudentSubjectScore>
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }

    public int LabScore { get; set; }
    public int LecScore { get; set; }
    public int ExamScore { get; set; }

    // //
    public StudentSubjectScore GetEntity(StudentSubjectScore entity = null)
    {
        entity ??= new();

        entity.StudentId = StudentId;
        entity.SubjectId = SubjectId;

        entity.LabScore = LabScore;
        entity.LecScore = LecScore;
        entity.ExamScore = ExamScore;

        return entity;
    }
}
