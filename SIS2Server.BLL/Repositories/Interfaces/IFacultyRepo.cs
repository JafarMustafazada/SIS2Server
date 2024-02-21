using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Repositories.Interfaces;

public interface IFacultyRepo : IGenericRepo<Faculty>
{
    Task AddSubject(int facultyId, int subjectId, int semester);
    Task RemoveSubject(int facultyId, int subjectId);
}
