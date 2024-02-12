using SIS2Server.Core.Common;

namespace SIS2Server.BLL.Exceptions.Common;

public class NotFoundException<T> : SIS2Exceptions where T : BaseEntity
{
    public NotFoundException() : base(typeof(T).Name + " not found")
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }
}
