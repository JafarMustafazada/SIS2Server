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
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.Core.Entities.UserRelated;
using SIS2Server.DAL.Contexts;

namespace SIS2Server.BLL.Extensions;

public static class FeatureAddingExtensions
{
    //static async Task CreateEntities<TRepo, TEntity>(IEnumerable<TEntity> entities, TRepo repo) 
    //    where TEntity : BaseEntity 
    //    where TRepo : IGenericRepo<TEntity>
    //{
    //    foreach (var entity in entities)
    //    {
    //        await repo.CreateAsync(entity);
    //    }
    //    await repo.SaveAsync();
    //}
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
    static async Task CreateUser(UserManager<AppUser> userManager, string role, IReadOnlyDictionary<string, string> info)
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

                IFamilyRelationRepo familyRepo = scope.ServiceProvider.GetRequiredService<IFamilyRelationRepo>();
                ISubjectRepo subjectRepo = scope.ServiceProvider.GetRequiredService<ISubjectRepo>();

                await CreateRoles(roleManager, Enum.GetNames<ConstRoles.UserRoles>());
                await CreateRoles(roleManager, Enum.GetNames<ConstRoles.EducationRoles>());

                await CreateUser(userManager, nameof(ConstRoles.UserRoles.SuperAdmin), 
                    app.Configuration.GetSection("SuperAdmin").Get<Dictionary<string, string>>());

                foreach (string item in Enum.GetNames<ConstFamilyReletaions>())
                {
                    if (await familyRepo.IsExistAsync(e => e.Name == item)) continue;

                    FamilyReletaion entity = new()
                    {
                        Name = item,
                    };

                    await familyRepo.CreateAsync(entity);
                    await familyRepo.SaveAsync();
                }

                foreach (string item in ConstSubjects.Standart1.Split(','))
                {
                    if (await subjectRepo.IsExistAsync(e => e.Name == item)) continue;

                    Subject entity = new()
                    { 
                        Name = item,
                    };

                    await subjectRepo.CreateAsync(entity);
                    await subjectRepo.SaveAsync();
                }
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
        services.AddScoped<ITeacherService, TeacherService>();

        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IFacultyService, FacultyService>();

        return services;
    }
    public static IServiceCollection AddSisRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepo, StudentRepo>();
        services.AddScoped<ITeacherRepo, TeacherRepo>();

        services.AddScoped<IFamilyMemberRepo, FamilyMemberRepo>();
        services.AddScoped<IFamilyRelationRepo, FamilyRelationRepo>();

        services.AddScoped<IFacultyRepo, FacultyRepo>();
        services.AddScoped<ISubjectRepo, SubjectRepo>();
        services.AddScoped<IGroupRepo, GroupRepo>();

        return services;
    }
    public static IServiceCollection AddSisDtoValidators(this IServiceCollection services)
    {
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidator>());
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<StudentCreateDtoValidator>());

        return services;
    }
}
