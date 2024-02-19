using SIS2Server.BLL.DTO.FacultyDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Services.Implements;

public class FacultyService : GenericCUDService<Faculty, IFacultyRepo, FacultyCreateDto>, IFacultyService
{
    IFacultyRepo _repo { get; }

    public FacultyService(IFacultyRepo repo) : base(repo)
    {
        this._repo = repo;
    }

    public IEnumerable<FacultyGeneralDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public FacultyDto GetById(int id)
    {
        throw new NotImplementedException();
    }
}
