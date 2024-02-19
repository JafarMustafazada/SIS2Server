using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class SubjectRepo(SIS02DbContext context) : GenericRepo<Subject>(context), ISubjectRepo
{
}
