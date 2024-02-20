using SIS2Server.BLL.DTO.TeacherDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class TeacherService : GenericCUDService<Teacher, ITeacherRepo, TeacherCreateDto>, ITeacherService
{
    ITeacherRepo _repo { get; }
    ISubjectRepo _subjectRepo { get; }

    public TeacherService(ITeacherRepo repo, ISubjectRepo subjectRepo) : base(repo)
    {
        this._repo = repo;
        this._subjectRepo = subjectRepo;
    }

    // //
    public async Task AddSubjectAsync(int techerId, int subjectId, bool remove = false)
    {
        this._subjectRepo.CheckId(subjectId);

        if (remove)
        {
            await this._repo.RemoveSubject(techerId, subjectId);
        }
        else
        {
            await this._repo.AddSubject(techerId, subjectId);
        }
    }

    public IEnumerable<TeacherGeneralDto> GetAll()
    {
        return TeacherGeneralDto.SetEntities(this._repo.GetAll());
    }

    public TeacherDto GetById(int id)
    {
        return TeacherDto.SetEntities(this._repo.CheckId(id)).First();
    }
}
