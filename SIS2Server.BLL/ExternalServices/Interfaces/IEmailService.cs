namespace SIS2Server.BLL.ExternalServices.Interfaces;

public interface IEmailService
{
    bool Send(string mail, string subject, string body, bool isHtml);
}
