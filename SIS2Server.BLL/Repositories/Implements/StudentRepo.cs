﻿using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Repositories.Implements;

public class StudentRepo(SIS02DbContext context) : GenericRepo<Student>(context), IStudentRepo
{
    public async Task AddToUser(int entityId, string userId)
    {
        this.CheckId(entityId);

        await context.UserStudents.AddAsync(new()
        {
            AppUserId = userId,
            StudentId = entityId,
        });

        await context.SaveChangesAsync();
    }
}
