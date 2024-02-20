using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Repositories.Interfaces;

public interface ITeacherRepo : IGenericRepo<Teacher>, IUserRelationRepo
{
    Task AddSubject(int teacherId, int subjectId);
    Task RemoveSubject(int teacherId, int subjectId);
}
