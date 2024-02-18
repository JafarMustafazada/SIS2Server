using SIS2Server.BLL.DTO.GroupDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Services.Implements;

public class GroupService : GenericCUDService<Group, IGroupRepo, GroupCreateDto>, IGroupService
{
    //IGroupRepo _repo { get; }

    public GroupService(IGroupRepo repo) : base(repo)
    {
        //this._repo = repo;
    }

    // //

}
