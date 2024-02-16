using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.Core.Constants;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IAuthService
{
    public Task Register(RegisterDto dto);
    public Task<bool> ConfirmRegistration(string confirmation);
    public Task<string> Login(LoginDto dto);
    public Task<bool> ChangeUserRole(string username, ConstRoles.UserRoles role);
}
