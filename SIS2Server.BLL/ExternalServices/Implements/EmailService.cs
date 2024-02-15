using Microsoft.Extensions.Configuration;
using SIS2Server.BLL.ExternalServices.Interfaces;
using System.Net.Mail;
using System.Net;

namespace SIS2Server.BLL.ExternalServices.Implements;

public class EmailService : IEmailService
{
    public static bool NeedUpdate { get; set; } = true;
    public static SmtpClient Client { get; private set; }
    public static MailAddress Support { get; private set; }

    public EmailService(IConfiguration configuration)
    {
        if (EmailService.NeedUpdate)
        {
            Client = new SmtpClient(configuration["Email:Host"],
                Convert.ToInt32(configuration["Email:Port"]));

            Client.EnableSsl = true;

            string email = configuration["Email:Username"] + '@' + configuration["Email:Domain"];

            Client.Credentials = new NetworkCredential(email, configuration["Email:Password"]);

            Support = new MailAddress(email, "Enderg Fun Games");

            EmailService.NeedUpdate = false;
        }
    }

    public bool Send(string mail, string subject, string body, bool isHtml)
    {
        MailAddress to = new(mail);
        MailMessage message = new(EmailService.Support, to)
        {
            Body = body,
            Subject = subject,
            IsBodyHtml = isHtml
        };

        Client.Send(message);
        return true;
    }
}
