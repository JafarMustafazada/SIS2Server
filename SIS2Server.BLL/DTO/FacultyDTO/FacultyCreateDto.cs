using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.FacultyDTO;

public class FacultyCreateDto : IBaseDto<Faculty>
{
    public string Name { get; set; }

    // //
    public Faculty GetEntity(Faculty entity = null)
    {
        entity ??= new();

        entity.Name = Name;

        return entity;
    }
}
