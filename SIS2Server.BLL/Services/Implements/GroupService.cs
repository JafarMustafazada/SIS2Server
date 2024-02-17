using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;

namespace SIS2Server.BLL.Services.Implements;

public class GroupService : IGroupService
{
    IGroupRepo _repo { get; }

    public GroupService(IGroupRepo repo)
    {
        this._repo = repo;
    }

    // //


}
