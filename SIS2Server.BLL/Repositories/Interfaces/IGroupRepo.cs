using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Repositories.Interfaces;

public interface IGroupRepo : IGenericRepo<Group>
{
    Task AddTeacher(int teacherId, int groupId);
}
