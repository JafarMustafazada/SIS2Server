using SIS2Server.BLL.DTO.FacultyDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Services.Implements;

public class FacultyService : GenericCUDService<Faculty, IFacultyRepo, FacultyCreateDto>, IFacultyService
{
    IFacultyRepo _repo { get; }
    ISubjectRepo _subjectRepo { get; }

    public FacultyService(IFacultyRepo repo, ISubjectRepo subjectRepo) : base(repo)
    {
        this._repo = repo;
        this._subjectRepo = subjectRepo;
    }

    public IEnumerable<FacultyGeneralDto> GetAll()
    {
        return FacultyGeneralDto.SetEntites(this._repo.GetAll());
    }

    public FacultyDto GetById(int id)
    {
        return FacultyDto.SetEntities(this._repo.CheckId(id)).First();
    }

    public async Task AddSubject(int facultyId, int subjectId, bool remove = false, int semester = 1)
    {
        this._subjectRepo.CheckId(subjectId);

        if (remove)
        {
            await this._repo.RemoveSubject(facultyId, subjectId);
        }
        else
        {
            await this._repo.AddSubject(facultyId, subjectId, semester);
        }
    }
}
