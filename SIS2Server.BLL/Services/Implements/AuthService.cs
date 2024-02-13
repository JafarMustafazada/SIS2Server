using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SIS2Server.BLL.DTO.UserRelatedDTO;
using SIS2Server.BLL.Exceptions.Auth;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class AuthService : IAuthService
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }
    IHttpContextAccessor _context { get; }
    IEmailService _emailService { get; }
    IConfiguration _configuration { get; }

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor context,
        IEmailService emailService,
        IConfiguration configuration)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._context = context;
        this._emailService = emailService;
        this._configuration = configuration;
    }

    public async Task CreateRoles()
    {
        foreach (string item in Enum.GetNames<ConstRoles.RoleEnum>())
        {
            if (!await this._roleManager.RoleExistsAsync(item))
            {
                var result = await this._roleManager.CreateAsync(new IdentityRole(item));
                if (!result.Succeeded) return; //throw 
            }
        }
    }

    public async Task Register(RegisterDto dto)
    {
        AppUser user = dto.GetEntity();

        var result = await this._userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) throw new UserExistException();

        //result = 
        await this._userManager.AddToRoleAsync(user, nameof(ConstRoles.RoleEnum.User));
        //if (!result.Succeeded) return false;

        string confirmationLink = "http://" + this._context.HttpContext.Request.Host.Value 
            + this._configuration["CustomEP:ConfirmationLink"] + "token";

        this._emailService.Send(dto.Email, "Welcome to club buddy", this.HtmlTemplate(confirmationLink), true);
    }

    string HtmlTemplate(string link, string name= "Confirm Link")
    {
        string tag = "<a href='" + link + "'>" + name + "</a>";
        string path = this._configuration["ConfirmationHtmlPath"];

        if (File.Exists(path))
        {
            string html = "";

            using (StreamReader sr = new(path))
            {
                string line = sr.ReadLine();
                while (!line.Contains(name))
                {
                    html += line;
                    line = sr.ReadLine();
                }

                html += tag;
                html += sr.ReadToEnd();
            }

            return html;
        }
        else return tag;
    }


    public async Task<bool> ConfirmRegistration(string token)
    {
        throw new NotImplementedException();
    }

    public Task<string> Login(LoginDto dto)
    {
        throw new NotImplementedException();
    }

}
