using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class InvalidLoginException : SIS2Exceptions
{
    public InvalidLoginException(string? message = "Wrong Username or Email or Password") : base(message)
    {
    }
}
