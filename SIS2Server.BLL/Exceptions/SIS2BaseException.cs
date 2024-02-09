namespace SIS2Server.BLL.Exceptions;

public abstract class SIS2BaseException : Exception
{
    protected SIS2BaseException(string? message = "Not implomented") : base(message)
    {
    }
}
