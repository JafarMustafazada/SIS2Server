using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.FamilyMmemberDTO;

public class FamilyMmemberDto : IBaseDto<FamilyMember>
{
    public int Id { get; set; }
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
    public string Relation { get; set; }

    // //
    public FamilyMember GetEntity(FamilyMember entity = null)
    {
        throw new NotImplementedException();
    }

    static FamilyMmemberDto SetEntity(FamilyMember item)
    {
        return new()
        {
            Id = item.Id,
            StudentId = item.StudentId,
            RelationId = item.FamilyReletaionId,

            Name = item.Name,
            Surname = item.Surname,
            Gender = item.Gender,
            Birthday = item.Birthday,
            Patronymic = item.Patronymic,
            PlaceOfLiving = item.PlaceOfLiving,

            PhoneNumber = item.PhoneNumber,
            Email = item.Email,

            Relation = item.FamilyReletaion.Name,
        };
    }

    public static IEnumerable<FamilyMmemberDto> SetEntities(IQueryable<FamilyMember> querry)
        => querry.Include(e => e.FamilyReletaion).Select(e => FamilyMmemberDto.SetEntity(e));

    public static IEnumerable<FamilyMmemberDto> SetEntities(IQueryable<Student> querry)
    {
        IEnumerable<Student> entities = querry
            .Include(e => e.FamilyMembers)
            .ThenInclude(e2 => e2.FamilyReletaion)
            .Select(e => e);

        List<FamilyMmemberDto> dtos = [];
        foreach (Student entity in entities)
        {
            dtos.AddRange(FamilyMmemberDto.SetEntities(entity));
        }

        return dtos;
    }

    public static IEnumerable<FamilyMmemberDto> SetEntities(Student student)
    {
        List<FamilyMmemberDto> dtos = [];

        if (student.FamilyMembers != null)
        {
            foreach (var item in student.FamilyMembers)
            {
                dtos.Add(FamilyMmemberDto.SetEntity(item));
            }
        }

        return dtos;
    }
}
