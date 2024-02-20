using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.TeacherDTO;

public class TeacherGeneralDto : IBaseDto<Teacher>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    // //
    public Teacher GetEntity(Teacher entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<TeacherGeneralDto> SetEntities(IQueryable<Teacher> querry)
    {
        return querry.Select(e => new TeacherGeneralDto
        {
            Id = e.Id,
            Name = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
        });
    }
}
