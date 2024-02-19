using SIS2Server.BLL.DTO.FamilyMmemberDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class FamilyService : GenericCUDService<FamilyMember, IFamilyMemberRepo, FamilyMemberCreateDto>, IFamilyService
{
    IFamilyMemberRepo _repo { get; }
    IFamilyRelationRepo _relationRepo {  get; }

    public FamilyService(IFamilyMemberRepo repo, IFamilyRelationRepo relationRepo) : base(repo)
    {
        this._repo = repo;
        this._relationRepo = relationRepo;
    }

    // //
    public IEnumerable<FamilyMmemberDto> GetAll()
    {
        return FamilyMmemberDto.SetEntities(this._repo.GetAll());
    }

    public IEnumerable<FamilyRelationDto> GetAllRelations()
    {
        return FamilyRelationDto.SetEntities(this._relationRepo.GetAll());
    }

    public FamilyMmemberDto GetById(int id)
    {
        return FamilyMmemberDto.SetEntities(this._repo.CheckId(id)).First();
    }
}
