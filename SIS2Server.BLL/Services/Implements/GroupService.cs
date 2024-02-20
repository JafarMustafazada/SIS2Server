using SIS2Server.BLL.DTO.GroupDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Services.Implements;

public class GroupService : GenericCUDService<Group, IGroupRepo, GroupCreateDto>, IGroupService
{
    IGroupRepo _repo { get; }
    ITeacherRepo _teacherRepo { get; }

    public GroupService(IGroupRepo repo, ITeacherRepo teacherRepo) : base(repo)
    {
        this._repo = repo;
        this._teacherRepo = teacherRepo;
    }

    // //
    public IEnumerable<GroupDto> GetAll()
    {
        return GroupDto.SetEntities(this._repo.GetAll());
    }

    public GroupDto GetById(int id)
    {
        return GroupDto.SetEntities(this._repo.CheckId(id)).First();
    }

    public async Task AddTeacherAsync(int teacherId, int groupId)
    {
        this._teacherRepo.CheckId(teacherId);
        await this._repo.AddTeacher(teacherId, groupId);
    }
}
