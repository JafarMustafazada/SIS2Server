using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.Core.Constants;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IAuthService
{
    Task Register(RegisterDto dto);
    Task<bool> ConfirmRegistration(string confirmation);
    Task<string> Login(LoginDto dto);
    Task<bool> ChangeUserRole(string username, ConstRoles.UserRoles role);
    Task<bool> ModifyEducationRole(string username, ConstRoles.EducationRoles role, int entityId);
}
