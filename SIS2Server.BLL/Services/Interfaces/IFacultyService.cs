using SIS2Server.BLL.DTO.FacultyDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IFacultyService
{
    public IEnumerable<FacultyGeneralDto> GetAll();
    public FacultyDto GetById(int id);
    public Task CreateAsync(FacultyCreateDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, FacultyCreateDto dto); 
}
