using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class RoleAddException : SIS2Exceptions
{
    public RoleAddException(string? message = "Error within role creating") : base(message)
    {
    }
}
