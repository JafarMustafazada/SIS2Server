namespace SIS2Server.Core.Constants;

public static class ConstRoles
{
    public enum RoleEnum
    {
        User,
        Admin,
        SuperAdmin,
        Student,
        Teacher,
    }

    /// <summary>
    /// Access level for every university member
    /// </summary>
    public const string AccessLevel1 = nameof(RoleEnum.SuperAdmin)
        + ", " + nameof(RoleEnum.Admin)
        + ", " + nameof(RoleEnum.Teacher)
        + ", " + nameof(RoleEnum.Student);

    /// <summary>
    /// Access level for every staff member
    /// </summary>
    public const string AccessLevel2 = nameof(RoleEnum.SuperAdmin)
        + ", " + nameof(RoleEnum.Admin)
        + ", " + nameof(RoleEnum.Teacher);

    /// <summary>
    /// Access level only for administration
    /// </summary>
    public const string AccessLevel3 = nameof(RoleEnum.SuperAdmin)
        + ", " + nameof(RoleEnum.Admin);
}
