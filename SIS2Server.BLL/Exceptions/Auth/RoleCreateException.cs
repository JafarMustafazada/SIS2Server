using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class RoleCreateException : SIS2Exceptions
{
    public RoleCreateException(string? message = "Error within role creating") : base(message)
    {
    }
}
