using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.TeacherDTO;

public class TeacherDto : IBaseDto<Teacher>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string PlaceOfLiving { get; set; }
    public bool Gender { get; set; } = true;
    public DateTime Birthday { get; set; }

    // //
    public string Proficiency { get; set; }
    public decimal Salary { get; set; }
    public DateTime Entered { get; set; }
    public DateTime Expiration { get; set; }

    public IEnumerable<string> Subjects { get; set; }
    public IEnumerable<string> GroupNames { get; set; }

    // //
    public Teacher GetEntity(Teacher entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<TeacherDto> SetEntities(IQueryable<Teacher> querry)
    {
        return querry.Include(e => e.TeacherSubjects).ThenInclude(e2 => e2.Subject)
            .Include(e => e.TeacherGroups).ThenInclude(e3 => e3.Group)
            .Select(e => new TeacherDto()
            {
                    Name = e.Name,
                    Surname = e.Surname,
                    Patronymic = e.Patronymic,
                    PlaceOfLiving = e.PlaceOfLiving,
                    Gender = e.Gender,
                    Birthday = e.Birthday,

                    Proficiency = e.Proficiency,
                    Salary = e.Salary,
                    Entered = e.Entered,
                    Expiration = e.Expiration,

                    Subjects = e.TeacherSubjects.Select(e2 => e2.Subject.Name),
                    GroupNames = e.TeacherGroups.Select(e3 => e3.Group.Name),
            });
    }
}
