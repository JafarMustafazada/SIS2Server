using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.StudentRelated;

namespace SIS2Server.BLL.DTO.SubjectDTO;

public class SubjectAttendanceDto : IBaseDto<StudentSubjectAttendance>
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }

    public int HoursSkipped { get; set; }

    // //
    public StudentSubjectAttendance GetEntity(StudentSubjectAttendance entity = null)
    {
        entity ??= new();

        entity.StudentId = entity.StudentId;
        entity.SubjectId = entity.SubjectId;
        entity.HoursSkipped = entity.HoursSkipped;

        return entity;
    }
}
