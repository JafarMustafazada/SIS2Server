using SIS2Server.BLL.DTO.TeacherDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface ITeacherService
{
    public IEnumerable<TeacherGeneralDto> GetAll();
    public TeacherDto GetById(int id);
    public Task CreateAsync(TeacherCreateDto dto);
    public Task AddSubjectAsync(int techerId, int subjectId, bool remove = false);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, TeacherCreateDto dto);
}
