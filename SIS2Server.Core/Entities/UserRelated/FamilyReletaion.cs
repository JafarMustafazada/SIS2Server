using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.UserRelated;

public class FamilyReletaion : BaseEntity
{
    public string Name { get; set; }

    // //
    public IEnumerable<FamilyMember> FamilyMembers { get; set; }
}
