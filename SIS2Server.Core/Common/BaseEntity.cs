namespace SIS2Server.Core.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public virtual bool IsActive { get; set; } = true;
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
