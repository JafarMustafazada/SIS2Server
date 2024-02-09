using SIS2Server.BLL.DTO.UserRelatedDTO;

namespace SIS2Server.BLL.Services.Interfaces;

public interface IAuthService
{
    public Task<bool> Register(RegisterDto dto);
    //public Task<TokenDto> Login(LoginDto dto);
    //public void SendConfirmation(LoginDto dto);
    //public Task<bool> ConfirmEmail(string token, bool skipValidation = true);
    public Task CreateRoles();
}
