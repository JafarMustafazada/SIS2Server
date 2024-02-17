using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.GroupDTO;

public class GroupGeneralDto : IBaseDto<Group>
{
    public int Id { get; set; }
    public int FacultyId { get; set; }

    public string Name { get; set; }


    // //
    public Group GetEntity(Group entity = null)
    {
        throw new NotImplementedException();
    }
}
