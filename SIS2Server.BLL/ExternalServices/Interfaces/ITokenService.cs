using Microsoft.IdentityModel.Tokens;
using SIS2Server.BLL.DTO.UserRelatedDTO;
using SIS2Server.Core.Entities.UserRelated;
using System.Text;

namespace SIS2Server.BLL.ExternalServices.Interfaces;

public interface ITokenService
{
    string CreateUserToken(AppUser user);
    static TokenValidationParameters TokenValidator(Dictionary<string, string> parameters)
    {
        return new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = parameters["Issuer"],
            ValidAudience = parameters["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(parameters["Salt"])),
            LifetimeValidator = (nb, exp, token, _) => token != null && exp > DateTime.UtcNow && nb < DateTime.UtcNow,
        };
    }
}
