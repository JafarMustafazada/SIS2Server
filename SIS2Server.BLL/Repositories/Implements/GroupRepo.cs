using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class GroupRepo : GenericRepo<Group>, IGroupRepo
{
    public GroupRepo(SIS02DbContext context) : base(context)
    {
    }
}
