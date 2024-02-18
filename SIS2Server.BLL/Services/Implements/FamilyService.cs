using SIS2Server.BLL.DTO.FamilyMmemberDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class FamilyService : GenericCUDService<FamilyMember, IFamilyMemberRepo, FamilyMemberCreateDto>, IFamilyService
{
    //IFamilyMemberRepo _repo { get; }

    public FamilyService(IFamilyMemberRepo repo) : base(repo)
    {
        //this._repo = repo;
    }

    // //
    public IEnumerable<FamilyMmemberDto> GetAll(int studentId)
    {
        throw new NotImplementedException();
    }

    public FamilyMmemberDto GetById(int id)
    {
        throw new NotImplementedException();
    }
}
