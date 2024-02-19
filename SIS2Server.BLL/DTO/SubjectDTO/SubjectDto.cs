using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.SubjectDTO;

public class SubjectDto : IBaseDto<Subject>
{
    public int Id { get; set; }
    public int Name { get; set; }

    // //
    public Subject GetEntity(Subject entity = null)
    {
        throw new NotImplementedException();
    }
}
