using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class FacultyRepo(SIS02DbContext context) : GenericRepo<Faculty>(context), IFacultyRepo
{
    public async Task AddSubject(int facultyId, int subjectId, int semester)
    {
        this.CheckId(facultyId);

        await context.FacultySubjects.AddAsync(new()
        {
            FacultyId = facultyId,
            SubjectId = subjectId,
            Semester = semester,
        });

        await context.SaveChangesAsync();
    }

    public async Task RemoveSubject(int facultyId, int subjectId)
    {
        this.CheckId(facultyId);

        FacultySubject? entity = context.FacultySubjects
            .Where(e => e.FacultyId == facultyId && e.SubjectId == subjectId)
            .FirstOrDefault();

        if (entity != null)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
