using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class FamilyMember : PersonEntity
{
    public int StudentId { get; set; }
    public int FamilyReletaionId { get; set; }

    // //
    public string PhoneNumber { get; set; } = "-";
    public string Email { get; set; } = "-";

    // //
    public Student? Student { get; set; }
    public FamilyReletaion? FamilyReletaion { get; set; }
}
