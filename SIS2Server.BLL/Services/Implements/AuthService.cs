using Microsoft.AspNetCore.Identity;
using SIS2Server.BLL.DTO.UserRelatedDTO;
using SIS2Server.BLL.Exceptions;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class AuthService : IAuthService
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }

    public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
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

    public async Task<bool> Register(RegisterDto dto)
    {
        AppUser user = dto.GetEntity();

        var result = await this._userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) throw new UsernameOrEmailExistException();

        //result = 
        await this._userManager.AddToRoleAsync(user, nameof(ConstRoles.RoleEnum.User));
        //if (!result.Succeeded) return false;

        //this.SendConfirmation(await AppUserDto.Create(user, this._userManager));

        return true;
    }
}
