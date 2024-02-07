using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.UserRelatedDTO;

public class RegisterDto
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public RegisterDto()
    {

    }
    //public RegisterDTO(AppUser user)
    //{

    //}
    public AppUser ToEntity()
    {
        return new()
        {
            UserName = this.UserName,

        };
    }
}

// DTO template
//public RegisterDTO()
//{

//}
//public RegisterDTO(AppUser user)
//{

//}
//public AppUser ToEntity()
//{
//    return default;
//}
