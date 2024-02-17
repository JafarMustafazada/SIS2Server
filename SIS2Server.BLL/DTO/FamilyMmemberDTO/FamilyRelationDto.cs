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
        entity ??= new();

        entity.Name = Name;

        return entity;
    }

    public static IEnumerable<FamilyRelationDto> SetEntities()
    {
        return default;
    }
}
