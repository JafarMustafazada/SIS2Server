using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.UserDTO;

public class LoginDto : IBaseDto<AppUser>
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }

    public AppUser GetEntity(DbSet<AppUser> table = null)
    {
        throw new NotImplementedException();
    }

    public static implicit operator LoginDto(RegisterDto dto)
        => new() { Password = dto.Password, UserNameOrEmail = dto.UserName };
}
