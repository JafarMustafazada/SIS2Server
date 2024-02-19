using SIS2Server.BLL.DTO.GroupDTO;
using SIS2Server.BLL.DTO.SubjectDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface ISubjectService
{
    public IEnumerable<SubjectDto> GetAll();
    public SubjectDto GetById(int id);
    public Task CreateAsync(SubjectCreateDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, SubjectCreateDto dto);
}
