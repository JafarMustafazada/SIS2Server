using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.TeacherDTO;

public class TeacherCreateDto : IBaseDto<Teacher>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string PlaceOfLiving { get; set; }
    public bool Gender { get; set; } = true;
    public DateTime Birthday { get; set; }

    public string Proficiency { get; set; }
    public decimal Salary { get; set; }
    public DateTime Entered { get; set; }
    public DateTime Expiration { get; set; }

    // //
    public Teacher GetEntity(Teacher entity = null)
    {
        entity ??= new();

        entity.Name = Name;
        entity.Surname = Surname;
        entity.Patronymic = Patronymic;
        entity.PlaceOfLiving = PlaceOfLiving;
        entity.Gender = Gender;
        entity.Birthday = Birthday;

        entity.Salary = Salary;
        entity.Proficiency = Proficiency;
        entity.Entered = Entered;
        entity.Expiration = Expiration;

        return entity;
    }
}
