namespace SIS2Server.Core.Common;

public class PersonEntity : BaseEntity
{
    // //
    public virtual string Name { get; set; }
    public virtual string Surname { get; set; }
    public virtual string Patronymic { get; set; }
    public virtual DateOnly Birthday { get; set; }
}
