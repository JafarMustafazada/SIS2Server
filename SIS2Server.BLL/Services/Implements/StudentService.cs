using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.Services.Interfaces;

namespace SIS2Server.BLL.Services.Implements;

public class StudentService : IStudentService
{
    public Task CreateAsync(StudentFullDto dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<StudentGeneralDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<StudentGeneralDto> GetByGroupIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, bool soft = true)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, StudentFullDto dto)
    {
        throw new NotImplementedException();
    }
}
