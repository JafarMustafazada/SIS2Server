using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIS2Server.BLL.Exceptions.Auth;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;
using System.Text;

namespace SIS2Server.BLL.Extensions;

public static class FeatureAddingExtensions
{
    static string ParseResultErrors(IEnumerable<IdentityError> errors)
    {
        StringBuilder sb = new();
        foreach (IdentityError error in errors)
        {
            sb.Append(error.Description);
            sb.Append(Environment.NewLine);
        }
        return sb.ToString().Trim();
    }

    // //
    static async Task CreateRoles(RoleManager<IdentityRole> roleManager, string[] roles)
    {
        foreach (string item in roles)
        {
            if (!await roleManager.RoleExistsAsync(item))
            {
                var result = await roleManager.CreateAsync(new IdentityRole
                {
                    Name = item
                });
                if (!result.Succeeded) throw new RoleCreateException(ParseResultErrors(result.Errors));
            }
        }
    }
    static async Task CreateSuperAdmin(UserManager<AppUser> userManager, Dictionary<string, string> info)
    {
        if (await userManager.FindByNameAsync(info["UserName"]) == null)
        {
            AppUser user = new()
            {
                UserName = info["UserName"],
                Email = info["Email"],
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, info["Password"]);
            if (!result.Succeeded) throw new UserExistException(ParseResultErrors(result.Errors));

            result = await userManager.AddToRoleAsync(user, nameof(ConstRoles.RoleEnum.SuperAdmin));
            if (!result.Succeeded) throw new RoleAddException(ParseResultErrors(result.Errors));
        }
    }

    // //
    public static WebApplication UseSeedData(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await CreateRoles(roleManager, Enum.GetNames<ConstRoles.RoleEnum>());
                await CreateSuperAdmin(userManager, app.Configuration.GetSection("SuperAdmin").Get<Dictionary<string, string>>());
            }

            await next();
        });

        return app;
    }

    // //

}
