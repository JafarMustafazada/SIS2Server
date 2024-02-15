using SIS2Server.BLL.DTO.StudentDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IStudentService
{
    public IEnumerable<StudentGeneralDto> GetAll();
    public Task<StudentGeneralDto> GetByGroupIdAsync(int id);
    public Task CreateAsync(StudentFullDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, StudentFullDto dto);
}
