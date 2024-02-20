using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class TeacherRepo(SIS02DbContext context) : GenericRepo<Teacher>(context), ITeacherRepo
{
    public async Task AddSubject(int teacherId, int subjectId)
    {
        this.CheckId(teacherId);

        await context.TeacherSubjects.AddAsync(new()
        {
            TeacherId = teacherId,
            SubjectId = subjectId,
        });

        await context.SaveChangesAsync();
    }

    public async Task RemoveSubject(int teacherId, int subjectId)
    {
        this.CheckId(teacherId);

        TeacherSubject entity = await context.TeacherSubjects
            .Where(e => e.TeacherId == teacherId && e.SubjectId == subjectId)
            .FirstAsync();
        context.Remove(entity);

        await context.SaveChangesAsync();
    }

    public async Task AddToUser(int entityId, string userId)
    {
        this.CheckId(entityId);

        await context.UserTeachers.AddAsync(new()
        {
            AppUserId = userId,
            TeacherId = entityId,
        });

        await context.SaveChangesAsync();
    }
}
