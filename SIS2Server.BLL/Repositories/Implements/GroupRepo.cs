using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class GroupRepo(SIS02DbContext context) : GenericRepo<Group>(context), IGroupRepo
{
    public async Task AddTeacher(int teacherId, int groupId)
    {
        this.CheckId(groupId);

        await context.TeacherGroups.AddAsync(new()
        {
            TeacherId = teacherId,
            GroupId = groupId,
        });

        await context.SaveChangesAsync();
    }
}
