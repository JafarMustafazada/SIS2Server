using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.StudentDTO;

public class StudentGeneralDto : IBaseDto<Student>
{
    public int Id { get; set; }
    public int GroupId { get; set; }

    public string GroupName { get; set; }
    public virtual string Name { get; set; }
    public virtual string Surname { get; set; }
    public virtual string Patronymic { get; set; }

    public bool HaveChangedGroup { get; set; } = false;

    // //
    public Student GetEntity(Student entity = null)
    {
        throw new NotImplementedException();
    }

    // //
    public static IEnumerable<StudentGeneralDto> SetEntities(IQueryable<Student> querry)
    {
        return querry.Include(e => e.Group).Include(e => e.StudentFormerGroups).Select(e => new StudentGeneralDto()
        {
            Id = e.Id,
            GroupId = e.GroupId,

            GroupName = e.Group.Name,
            Name = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,

            HaveChangedGroup = e.StudentFormerGroups.Any(),
        });
    }
}
