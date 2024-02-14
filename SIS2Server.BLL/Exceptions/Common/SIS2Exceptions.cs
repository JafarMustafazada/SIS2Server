namespace SIS2Server.BLL.Exceptions.Common;

public abstract class SIS2Exceptions : Exception
{
    protected SIS2Exceptions(string? message) : base(message)
    {
    }
}
