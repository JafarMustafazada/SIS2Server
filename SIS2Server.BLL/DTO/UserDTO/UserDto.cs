using Microsoft.AspNetCore.Identity;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.UserDTO;

public class UserDto : IBaseDto<AppUser>
{
    public string Username { get; set; }
    public string UserRole { get; set; } = null;
    public string EducationRole { get; set; } = null;

    // //
    public AppUser GetEntity(AppUser entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<UserDto> SetEntities(IEnumerable<AppUser> entities, UserManager<AppUser> userManager)
    {
        List<UserDto> dtos = [];
        UserDto dto;

        foreach (AppUser entity in entities)
        {
            dto = new();

            var roles = userManager.GetRolesAsync(entity).Result;
            roles.Any(r =>
            {
                if (Enum.IsDefined(typeof(ConstRoles.UserRoles), r))
                {
                    dto.UserRole = r;
                }
                else if (Enum.IsDefined(typeof(ConstRoles.EducationRoles), r))
                {
                    dto.EducationRole = r;
                }

                return dto.UserRole != null && dto.EducationRole != null;
            });

            dtos.Add(dto);
        }

        return dtos;
    }
}
