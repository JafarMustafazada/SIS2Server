using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.GroupDTO;

public class GroupDto : IBaseDto<Group>
{
    public int Id { get; set; }
    public int FacultyId { get; set; }

    // //
    public string Name { get; set; }
    public int CurrentSemester { get; set; }

    // //
    public Group GetEntity(Group entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<GroupDto> SetEntities(IQueryable<Group> querry)
    {
        return querry.Select(e => new GroupDto
        {
            Id = e.Id,
            FacultyId = e.FacultyId,
            Name = e.Name,
            CurrentSemester = e.CurrentSemester,
        });
    }
}
