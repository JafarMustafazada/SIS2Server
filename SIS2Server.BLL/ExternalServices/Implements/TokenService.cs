using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.Core.Entities.UserRelated;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIS2Server.BLL.ExternalServices.Implements;

public class TokenService : ITokenService
{
    Dictionary<string, string> _parameters { get; }

    public TokenService(IConfiguration configuration)
    {
        this._parameters = configuration.GetSection("Token")
            .Get<Dictionary<string, string>>();
    }

    public string CreateUserToken(AppUser user)
    {
        List<Claim> claims = new List<Claim>();
        claims.Add(new("UserName", user.UserName));
        claims.Add(new("Email", user.Email));
        claims.Add(new("PhoneNumber", user.PhoneNumber));

        DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(this._parameters["ExpireMinutes"]));

        SymmetricSecurityKey ssk = new(Encoding.UTF8.GetBytes(this._parameters["Salt"]));
        SigningCredentials sc = new(ssk, SecurityAlgorithms.HmacSha256Signature);
        JwtSecurityToken jst = new(this._parameters["Issuer"], this._parameters["Audience"], claims, DateTime.UtcNow, expires, sc);

        return new JwtSecurityTokenHandler().WriteToken(jst);
    }

    public async Task<bool> VakidateToken(string token)
    {
        JwtSecurityTokenHandler handler = new();
        var result = await handler.ValidateTokenAsync(token, ITokenService.TokenValidator(this._parameters));
        return result.IsValid;
    }
}
