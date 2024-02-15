﻿using SIS2Server.Core.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.Core.Entities.UserRelated;

public class Student : PersonEntity
{
    public int GroupId { get; set; }

    // //
    public DateOnly Entered { get; set; }
    public DateOnly Graduation { get; set; }
    public string Nationality { get; set; }

    // //
    public Group? Group { get; set; }
    public IEnumerable<UserStudent>? UserStudents { get; set; }
    public IEnumerable<FamilyMember>? FamilyMembers { get; set; }
    public IEnumerable<StudentGroupHistory>? StudentGroupHistories { get; set; }
}
