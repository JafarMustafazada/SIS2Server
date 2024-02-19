using Microsoft.AspNetCore.Http.HttpResults;
using SIS2Server.BLL.DTO.FamilyMmemberDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IFamilyService
{
    IEnumerable<FamilyMmemberDto> GetAll();
    IEnumerable<FamilyRelationDto> GetAllRelations();
    FamilyMmemberDto GetById(int id);
    Task CreateAsync(FamilyMemberCreateDto dto);
    Task RemoveAsync(int id, bool soft = true);
    Task UpdateAsync(int id, FamilyMemberCreateDto dto);
}
/*
    public IEnumerable<GeneralDto> GetAll(string querry = "-");
    public FullDto GetById(int id);
    public Task CreateAsync(CreateDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, CreateDto dto);
 */