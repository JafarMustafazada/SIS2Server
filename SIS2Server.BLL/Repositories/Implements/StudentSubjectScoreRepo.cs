using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.StudentRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class StudentSubjectScoreRepo(SIS02DbContext context) : GenericRepo<StudentSubjectScore>(context), IStudentSubjectScoreRepo
{
}
