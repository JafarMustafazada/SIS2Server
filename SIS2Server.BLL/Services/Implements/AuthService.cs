using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor context,
        IEmailService emailService)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._context = context;
        this._emailService = emailService;
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


        string confirmationLink = this._context.HttpContext?.ToString();
        this._emailService.Send(dto.Email, "Welcome to club buddy", confirmationLink, false);
    }

    public void ConfirmRegistration(string confirmation)
    {
        throw new NotImplementedException();
    }

    public Task<string> Login(LoginDto dto)
    {
        throw new NotImplementedException();
    }

}
