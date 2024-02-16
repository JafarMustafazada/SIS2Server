using SIS2Server.Core.Common;

namespace SIS2Server.BLL.Exceptions.Common;

public class ManySameKeyException<T> : SIS2Exceptions where T : BaseEntity
{
    public ManySameKeyException(string? message) : base(message)
    {
    }
    public ManySameKeyException() : base(typeof(T).Name + " has many same key entities")
    {
    }
}
