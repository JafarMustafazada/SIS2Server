using SIS2Server.BLL.DTO.SubjectDTO;
using SIS2Server.BLL.DTO.TeacherDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface ITeacherService
{
    IEnumerable<TeacherGeneralDto> GetAll();
    TeacherDto GetById(int id);
    Task CreateAsync(TeacherCreateDto dto);
    Task AddSubjectAsync(int techerId, int subjectId, bool remove = false);
    Task RemoveAsync(int id, bool soft = true);
    Task UpdateAsync(int id, TeacherCreateDto dto);
    bool ConfirmTeacher(string username, int subjectId, int studentId);
    Task ModifyScore(SubjectScoreDto dto);
    Task ModifyAttendanc(SubjectAttendanceDto dto);
}
