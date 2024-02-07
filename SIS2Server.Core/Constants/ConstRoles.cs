namespace SIS2Server.Core.Constants;

public static class ConstRoles
{
    public enum RoleNames
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
    public const string AccessLevel1 = nameof(RoleNames.SuperAdmin)
        + ", " + nameof(RoleNames.Admin)
        + ", " + nameof(RoleNames.Teacher)
        + ", " + nameof(RoleNames.Student);

    /// <summary>
    /// Access level for every staff member
    /// </summary>
    public const string AccessLevel2 = nameof(RoleNames.SuperAdmin)
        + ", " + nameof(RoleNames.Admin)
        + ", " + nameof(RoleNames.Teacher);

    /// <summary>
    /// Access level only for administration
    /// </summary>
    public const string AccessLevel3 = nameof(RoleNames.SuperAdmin)
        + ", " + nameof(RoleNames.Admin);
}
