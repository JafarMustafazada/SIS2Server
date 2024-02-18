using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.FamilyMmemberDTO;

public class FamilyMemberCreateDto : IBaseDto<FamilyMember>
{
    public int StudentId { get; set; }
    public int RelationId { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public bool Gender { get; set; }
    public string PlaceOfLiving { get; set; }
    public DateTime Birthday { get; set; }

    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    // //
    public FamilyMember GetEntity(FamilyMember entity = null)
    {
        entity ??= new();

        entity.StudentId = StudentId;
        entity.FamilyReletaionId = RelationId;

        entity.Name = Name;
        entity.Surname = Surname;
        entity.Gender = Gender;
        entity.PlaceOfLiving = PlaceOfLiving;
        entity.Birthday = Birthday;
        entity.PlaceOfLiving = PlaceOfLiving;

        entity.PhoneNumber = PhoneNumber;
        entity.Email = Email;

        return entity;
    }
}
