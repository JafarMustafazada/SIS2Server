using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace SIS2Server.BLL.Extensions;

public static class HelpfulExtensions
{
    public static string ParseDescriptions(this IEnumerable<IdentityError> errors)
    {
        StringBuilder sb = new();
        foreach (IdentityError error in errors)
        {
            sb.Append(error.Description);
            sb.Append(Environment.NewLine);
        }
        return sb.ToString().Trim();
    }

    // // this one is actually useless 
    public static bool HasUpperLower(this string test)
    {
        byte checker = 0;

        foreach (char c in test)
        {
            if (Char.IsLower(c)) checker |= 1;
            if (Char.IsUpper(c)) checker |= 2;
            if (checker == 3) return true;
        }

        return false;
    }

    // //
    public static Claim GetClaim(this IEnumerable<Claim> claims, string type)
        => claims.First(c => c.Type == type);

    // //
    public static IQueryable<T> Includes<T>(this IQueryable<T> query, params string[] includes) where T : class
    {
        if (includes?.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }
}
