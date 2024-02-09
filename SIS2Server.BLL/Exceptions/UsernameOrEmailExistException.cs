namespace SIS2Server.BLL.Exceptions;

public class UsernameOrEmailExistException : SIS2BaseException
{
    public UsernameOrEmailExistException(string message = "Username or email is not exist") : base(message)
    {
    }
}
