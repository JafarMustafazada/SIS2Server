using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.Core.Entities.UserRelated;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIS2Server.BLL.ExternalServices.Implements;

public class TokenService : ITokenService
{
    UserManager<AppUser> _userManager { get; set; }
    Dictionary<string, string> _parameters { get; }

    public TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        this._parameters = configuration.GetSection("Token")
            .Get<Dictionary<string, string>>();

        this._userManager = userManager;
    }

    public string CreateUserToken(AppUser user)
    {
        List<Claim> claims = new List<Claim>();
        claims.Add(new("UserName", user.UserName));
        claims.Add(new("Email", user.Email));
        claims.Add(new("PhoneNumber", user.PhoneNumber));

        foreach (string role in this._userManager.GetRolesAsync(user).Result)
        {
            claims.Add(new(this._parameters["RoleClaim"], role));
        }

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

    public IEnumerable<Claim> GetClaims(string token)
    {
        return new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
    }
}
