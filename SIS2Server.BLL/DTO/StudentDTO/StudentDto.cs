﻿using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.BLL.DTO.FamilyMmemberDTO;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.StudentDTO;

public class StudentDto : IBaseDto<Student>
{
    public int Id { get; set; }
    public int GroupId { get; set; }

    // //
    public string GroupName { get; set; }
    public string FacultyName { get; set; }
    public int CurrentSemester { get; set; }

    // //
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string PlaceOfLiving { get; set; }
    public bool Gender { get; set; } = true;
    public DateTime Birthday { get; set; }

    public DateTime Entered { get; set; }
    public DateTime Graduation { get; set; }
    public string Nationality { get; set; }

    IEnumerable<FamilyMmemberDto> FamilyMmembers { get; set; }


    // //
    public Student GetEntity(Student entity = null)
    {
        throw new NotImplementedException();
    }

    // //
    public static IEnumerable<StudentDto> SetEntities(IQueryable<Student> querry)
    {
        return querry.Include(e => e.FamilyMembers).ThenInclude(e3 => e3.FamilyReletaion)
        .Include(e => e.Group).ThenInclude(e2 => e2.Faculty).Select(e => new StudentDto()
        {
            Id = e.Id,
            GroupId = e.GroupId,

            GroupName = e.Group.Name,
            FacultyName = e.Group.Faculty.Name,
            CurrentSemester = e.Group.CurrentSemester,

            Name = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,

            PlaceOfLiving = e.PlaceOfLiving,
            Gender = e.Gender,
            Birthday = e.Birthday,
            Entered = e.Entered,
            Graduation = e.Graduation,
            Nationality = e.Nationality,

            FamilyMmembers = FamilyMmemberDto.SetEntities(e),
        });
    }
}