using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.StudentRelated;

namespace SIS2Server.BLL.DTO.StudentDTO;

public class StudentAttendanceDto : IBaseDto<StudentSubjectAttendance>
{
    public string SubjectName { get; set; }

    public int HoursSkipped { get; set; }

    // //
    public StudentSubjectAttendance GetEntity(StudentSubjectAttendance entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<StudentAttendanceDto> SetEntities(IQueryable<StudentSubjectAttendance> querry)
    {
        return querry.Include(ssa => ssa.Subject).Select(ssa => new StudentAttendanceDto
        {
            SubjectName = ssa.Subject.Name,

            HoursSkipped = ssa.HoursSkipped,
        });
    }
}
