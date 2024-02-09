using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.UserRelatedDTO;

public class LoginDto : IBaseDto<AppUser>
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }

    public AppUser GetEntity()
    {
        throw new NotImplementedException();
    }

    public void SetEntity(AppUser entity)
    {
        throw new NotImplementedException();
    }
}
