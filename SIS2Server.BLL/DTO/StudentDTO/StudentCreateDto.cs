using FluentValidation;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.BLL.Extensions;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.StudentDTO;

public class StudentCreateDto : IBaseDto<Student>
{
    public int GroupId { get; set; }

    // //
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string PlaceOfLiving { get; set; }
    public bool Gender { get; set; }
    public DateTime Birthday { get; set; }

    public DateOnly Entered { get; set; }
    public DateOnly Graduation { get; set; }
    public string Nationality { get; set; }

    // //
    public Student GetEntity(Student entity = null)
    {
        entity ??= new();

        entity.GroupId = this.GroupId;

        entity.Name = this.Name;
        entity.Surname = this.Surname;
        entity.Patronymic = this.Patronymic;
        entity.PlaceOfLiving = this.PlaceOfLiving;
        entity.Gender = this.Gender;
        entity.Birthday = this.Birthday;

        entity.Entered = this.Entered;
        entity.Graduation = this.Graduation;
        entity.Nationality = this.Nationality;

        return entity;
    }
}

public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
{
    public StudentCreateDtoValidator()
    {
        RuleFor(x => x.GroupId)
            .NotNullOrEmpty();

        RuleFor(x => x.Name)
            .NotNullOrEmpty()
            .CustomLength(2, 32);

        RuleFor(x => x.Surname)
            .NotNullOrEmpty()
            .CustomLength(2, 32);

        RuleFor(x => x.Patronymic)
            .NotNullOrEmpty()
            .CustomLength(2, 32);

        RuleFor(x => x.PlaceOfLiving)
            .NotNullOrEmpty()
            .CustomLength(2, 127);

        RuleFor(x => x.Gender)
            .NotNullOrEmpty();

        RuleFor(x => x.Birthday)
            .NotNullOrEmpty();
            //.CustomRange(DateOnly.FromDateTime(DateTime.));

        RuleFor(x => x.Entered)
            .NotNullOrEmpty();

        RuleFor(x => x.Graduation)
            .NotNullOrEmpty();

        RuleFor(x => x.Nationality)
            .NotNullOrEmpty()
            .CustomLength(2, 32);
    }
}