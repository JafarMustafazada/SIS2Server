using SIS2Server.BLL.DTO.GroupDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IGroupService
{
    IEnumerable<GroupDto> GetAll();
    GroupDto GetById(int id);
    Task CreateAsync(GroupCreateDto dto);
    Task RemoveAsync(int id, bool soft = true);
    Task UpdateAsync(int id, GroupCreateDto dto);
    Task AddTeacherAsync(int teacherId, int groupId, bool remove);
}
