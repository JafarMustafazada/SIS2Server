using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.StudentRelated;

namespace SIS2Server.BLL.DTO.StudentDTO;

public class StudentScoreDto : IBaseDto<StudentSubjectScore>
{
    public string SubjectName { get; set; }

    public int LabScore { get; set; }
    public int LecScore { get; set; }
    public int ExamScore { get; set; }

    // //
    public StudentSubjectScore GetEntity(StudentSubjectScore entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<StudentScoreDto> SetEntities(IQueryable<StudentSubjectScore> querry)
    {
        return querry.Include(sss => sss.Subject).Select(sss => new StudentScoreDto
        {
            SubjectName = sss.Subject.Name,

            LabScore = sss.LabScore,
            LecScore = sss.LecScore,
            ExamScore = sss.ExamScore,
        });
    }
}
