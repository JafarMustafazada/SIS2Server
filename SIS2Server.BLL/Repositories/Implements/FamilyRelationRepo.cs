using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class FamilyRelationRepo(SIS02DbContext context) : GenericRepo<FamilyReletaion>(context), IFamilyRelationRepo
{
}