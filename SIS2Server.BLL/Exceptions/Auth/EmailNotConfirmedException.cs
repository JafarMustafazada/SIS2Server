using SIS2Server.BLL.Exceptions.Common;

namespace SIS2Server.BLL.Exceptions.Auth;

public class EmailNotConfirmedException : SIS2Exceptions
{
    public EmailNotConfirmedException(string? message = "Email not confirmed. New confirmation was send") : base(message)
    {
    }
}
