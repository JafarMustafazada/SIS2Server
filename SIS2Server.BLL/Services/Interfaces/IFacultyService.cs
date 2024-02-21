using SIS2Server.BLL.DTO.FacultyDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IFacultyService
{
    IEnumerable<FacultyGeneralDto> GetAll();
    FacultyDto GetById(int id);
    Task CreateAsync(FacultyCreateDto dto);
    Task RemoveAsync(int id, bool soft = true);
    Task UpdateAsync(int id, FacultyCreateDto dto);
    Task AddSubject(int facultyId, int subjectId, bool remove = false, int semester = 1);
}
