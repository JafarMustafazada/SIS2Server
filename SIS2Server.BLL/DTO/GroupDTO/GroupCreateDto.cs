using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.GroupDTO;

public class GroupCreateDto : IBaseDto<Group>
{
    public int FacultyId { get; set; }

    public string Name { get; set; }
    public int CurrentSemester { get; set; }

    // //
    public Group GetEntity(Group entity = null)
    {
        entity ??= new();

        entity.FacultyId = FacultyId;
        entity.CurrentSemester = CurrentSemester;
        entity.Name = Name;

        return entity;
    }
}
