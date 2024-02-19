using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.FacultyDTO;

public class FacultyGeneralDto : IBaseDto<Faculty>
{
    public int Id { get; set; }

    public string Name { get; set; }

    // //
    public Faculty GetEntity(Faculty entity = null)
    {
        throw new NotImplementedException();
    }
}
