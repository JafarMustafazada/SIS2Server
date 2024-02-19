using SIS2Server.BLL.DTO.GroupDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IGroupService
{
    public IEnumerable<GroupDto> GetAll();
    public GroupDto GetById(int id);
    public Task CreateAsync(GroupCreateDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, GroupCreateDto dto);
}
