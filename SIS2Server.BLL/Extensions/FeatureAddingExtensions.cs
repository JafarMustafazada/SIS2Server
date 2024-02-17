using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.BLL.Exceptions.Auth;
using SIS2Server.BLL.ExternalServices.Implements;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.BLL.Repositories.Implements;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Implements;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Extensions;

public static class FeatureAddingExtensions
{
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
                if (!result.Succeeded) throw new RoleCreateException(result.Errors.ParseDescriptions());
            }
        }
    }
    static async Task CreateUser(UserManager<AppUser> userManager, string role, Dictionary<string, string> info)
    {
        if (await userManager.FindByNameAsync(info["UserName"]) == null)
        {
            AppUser user = new()
            {
                UserName = info["UserName"],
                Email = info["Email"],
                PhoneNumber = info["PhoneNumber"],
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, info["Password"]);
            if (!result.Succeeded) throw new UserExistException(result.Errors.ParseDescriptions());

            result = await userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded) throw new RoleAddException(result.Errors.ParseDescriptions());
        }
    }

    // //
    public static WebApplication UseSisSeedData(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await CreateRoles(roleManager, Enum.GetNames<ConstRoles.UserRoles>());
                await CreateRoles(roleManager, Enum.GetNames<ConstRoles.EducationRoles>());

                await CreateUser(userManager, nameof(ConstRoles.UserRoles.SuperAdmin), 
                    app.Configuration.GetSection("SuperAdmin").Get<Dictionary<string, string>>());
            }

            await next();
        });

        return app;
    }

    // //
    public static IServiceCollection AddSisIdentity(this IServiceCollection services, string connection)
    {
        services.AddDbContext<SIS02DbContext>(options =>
        {
            options.UseSqlServer(connection);
        }).AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.SignIn.RequireConfirmedEmail = true;
            opt.User.RequireUniqueEmail = true;
            opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
            opt.Lockout.MaxFailedAccessAttempts = 5;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 4;
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<SIS02DbContext>();

        return services;
    }
    public static IServiceCollection AddSisTokenAuth(this IServiceCollection services, Dictionary<string, string> parameters)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = ITokenService.TokenValidator(parameters);
        });
        services.AddAuthorization();

        return services;
    }
    public static IServiceCollection AddSisServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IGroupService, GroupService>();


        return services;
    }
    public static IServiceCollection AddSisRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepo, StudentRepo>();
        services.AddScoped<IGroupRepo, GroupRepo>();

        return services;
    }
    public static IServiceCollection AddSisDtoValidators(this IServiceCollection services)
    {
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidator>());
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<StudentCreateDtoValidator>());

        return services;
    }

    // //
    //public static IServiceCollection AddSisServiceCollection(this IServiceCollection services, IConfiguration configuration)
    //{


    //    return services;
    //}
}
