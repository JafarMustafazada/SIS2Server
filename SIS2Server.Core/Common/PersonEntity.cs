namespace SIS2Server.Core.Common;

public class PersonEntity : BaseEntity
{
    // //
    public virtual string Name { get; set; }
    public virtual string Surname { get; set; }
    public virtual string Patronymic { get; set; }
    public string PlaceOfLiving { get; set; }
    public bool Gender { get; set; } = true;
    public virtual DateOnly Birthday { get; set; }
}
