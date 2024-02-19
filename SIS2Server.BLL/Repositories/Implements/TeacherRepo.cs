using Microsoft.AspNetCore.Identity;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class TeacherRepo(SIS02DbContext context) : GenericRepo<Teacher>(context), ITeacherRepo
{
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
