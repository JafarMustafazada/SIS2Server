using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.BLL.Exceptions.Auth;
using SIS2Server.BLL.Extensions;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;
using System.Security.Claims;

namespace SIS2Server.BLL.Services.Implements;

public class AuthService : IAuthService
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }
    IHttpContextAccessor _context { get; }
    IEmailService _emailService { get; }
    IConfiguration _configuration { get; }
    ITokenService _tokenService { get; }
    ITeacherRepo _teacherRepo { get; }
    IStudentRepo _studentRepo { get; }

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor context,
        IEmailService emailService,
        IConfiguration configuration,
        ITokenService tokenService,
        ITeacherRepo teacherRepo,
        IStudentRepo studentRepo,)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._context = context;
        this._emailService = emailService;
        this._configuration = configuration;
        this._tokenService = tokenService;
        this._teacherRepo = teacherRepo;
        this._studentRepo = studentRepo;
    }

    //public async Task CreateRoles()
    //{
    //    foreach (string item in Enum.GetNames<ConstRoles.RoleEnum>())
    //    {
    //        if (!await this._roleManager.RoleExistsAsync(item))
    //        {
    //            var result = await this._roleManager.CreateAsync(new IdentityRole(item));
    //            if (!result.Succeeded) return; //throw 
    //        }
    //    }
    //}
    void SendConfirmation(AppUser user)
    {
        string confirmationLink = "http://" + this._context.HttpContext.Request.Host.Value
            + this._configuration["CustomEP:ConfirmationLink"] + this._tokenService.CreateUserToken(user);


        this._emailService.Send(user.Email, "Welcome to club buddy", this.HtmlTemplate(confirmationLink), true);
    }

    public async Task Register(RegisterDto dto)
    {
        AppUser user = dto.GetEntity();

        var result = await this._userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) throw new UserExistException();

        result = await this._userManager.AddToRoleAsync(user, nameof(ConstRoles.UserRoles.User));
        if (!result.Succeeded) throw new RoleAddException(result.Errors.ParseDescriptions());

        this.SendConfirmation(user);
    }

    string HtmlTemplate(string link, string name = "Confirm Link")
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
        if (await this._tokenService.VakidateToken(token))
        {
            IEnumerable<Claim> claims = this._tokenService.GetClaims(token);

            AppUser user = await this._userManager.FindByNameAsync(claims.GetClaim("UserName").Value);
            if (user == null || user.Email != claims.GetClaim("Email").Value)
                throw new InvalidLoginException();

            user.EmailConfirmed = true;
            await this._userManager.UpdateAsync(user);

            return true;
        }
        else return false;
    }

    public async Task<string> Login(LoginDto dto)
    {
        AppUser user;

        if (dto.UserNameOrEmail.Contains('@'))
        {
            user = await this._userManager.FindByEmailAsync(dto.UserNameOrEmail);
        }
        else
        {
            user = await this._userManager.FindByNameAsync(dto.UserNameOrEmail);
        }

        if (user == null || !(await this._userManager.CheckPasswordAsync(user, dto.Password)))
            throw new InvalidLoginException();

        if (!user.EmailConfirmed)
        {
            this.SendConfirmation(user);
            throw new EmailNotConfirmedException();
        }

        return this._tokenService.CreateUserToken(user);
    }

    public async Task<bool> ChangeUserRole(string username, ConstRoles.UserRoles role)
    {
        AppUser user = await this._userManager.FindByNameAsync(username) ?? throw new InvalidLoginException();

        List<string> rolesToRemove = new List<string>();
        foreach (string item in await this._userManager.GetRolesAsync(user))
        {
            if (Enum.IsDefined(typeof(ConstRoles.UserRoles), item))
            {
                rolesToRemove.Add(item);
            }
        }

        IdentityResult result = await this._userManager.RemoveFromRolesAsync(user, rolesToRemove);
        if (!result.Succeeded) throw new RoleRemoveException(result.Errors.ParseDescriptions());

        result = await this._userManager.AddToRoleAsync(user, role.ToString());
        if (!result.Succeeded) throw new RoleAddException(result.Errors.ParseDescriptions());

        return true;
    }

    public async Task<bool> AddEducationRoleOnce(string username, ConstRoles.EducationRoles role, int entityId)
    {
        AppUser user = await this._userManager.FindByNameAsync(username) ?? throw new InvalidLoginException();

        if (role == ConstRoles.EducationRoles.Student) await this._studentRepo.AddToUser(entityId, user.Id);
        else if (role == ConstRoles.EducationRoles.Teacher) await this._teacherRepo.AddToUser(entityId, user.Id);
        else return false;

        IdentityResult result = await this._userManager.AddToRoleAsync(user, role.ToString());
        if (!result.Succeeded) throw new RoleAddException(result.Errors.ParseDescriptions());

        return true;
    }
}
