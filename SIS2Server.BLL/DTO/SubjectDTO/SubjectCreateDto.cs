using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.SubjectDTO;

public class SubjectCreateDto : IBaseDto<Subject>
{
    public string Name { get; set; }

    // //
    public Subject GetEntity(Subject entity = null)
    {
        entity ??= new();

        entity.Name = this.Name;

        return entity;
    }
}
