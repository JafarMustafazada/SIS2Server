using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class FamilyReletaion : BaseEntity
{
    public string Tag { get; set; }

    // //
    public IEnumerable<FamilyMember> FamilyMembers { get; set; }
}
