using SIS2Server.Core.Common;

namespace SIS2Server.Core.Entities.SubjectRelated;

public class Faculty : BaseEntity
{
    public string Name { get; set; }

    // //
    public IEnumerable<Group>? Groups { get; set; }
}
