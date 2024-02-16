using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class RoleRemoveException : SIS2Exceptions
{
    public RoleRemoveException(string? message = "Error within role creating") : base(message)
    {
    }
}
