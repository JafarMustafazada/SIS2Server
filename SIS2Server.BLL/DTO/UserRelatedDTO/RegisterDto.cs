﻿using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.UserRelatedDTO;

public class RegisterDto : IBaseDto<AppUser>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public AppUser GetEntity()
    {
        return new()
        {
            UserName = this.UserName,
            Email = this.Email,
            PhoneNumber = this.PhoneNumber,
        };
    }

    public void SetEntity(AppUser entity)
    {
        throw new NotImplementedException();
    }
}
