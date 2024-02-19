using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.FamilyMmemberDTO;

public class FamilyRelationDto : IBaseDto<FamilyReletaion>
{
    public int Id { get; set; }
    public string Name { get; set; }

    // //
    public FamilyReletaion GetEntity(FamilyReletaion entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<FamilyRelationDto> SetEntities(IQueryable<FamilyReletaion> querry)
    {
        return querry.Select(e => new FamilyRelationDto()
        {
            Id = e.Id,
            Name = e.Name,
        });
    }
}
