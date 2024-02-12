using SIS2Server.BLL.DTO.UserRelatedDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IAuthService
{
    public Task Register(RegisterDto dto);
    public void ConfirmRegistration(string confirmation);
    public Task<string> Login(LoginDto dto);
    //public Task<bool> ConfirmEmail(string token, bool skipValidation = true);
    public Task CreateRoles();
}
