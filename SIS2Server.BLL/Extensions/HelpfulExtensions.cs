using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    // // this one is actually useless and only time consuming
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
    public static Dictionary<string, string> ParseRawQuerry(this string raw)
    {
        Dictionary<string, string> parsed = [];

        foreach (string item in raw.Split('&'))
        {
            int index = item.IndexOf('=');
            if (index < 0) break;
            string key = item[..index++];

            parsed[key] = item.Length > index ? item[index..] : "";
        }

        return parsed;
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
