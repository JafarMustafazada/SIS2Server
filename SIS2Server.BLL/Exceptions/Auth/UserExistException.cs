using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class UserExistException : SIS2Exceptions
{
    public UserExistException(string message = "Username or email is exist") : base(message)
    {
    }
}
