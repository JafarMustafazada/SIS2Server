namespace SIS2Server.Core.Constants;

public static class ConstRoles
{
    public enum UserRoles
    {
        SuperAdmin,
        Admin,
        User,
    }
    public enum EducationRoles
    {
        Teacher,
        Student,
    }

    /// <summary>
    /// Absolute access.
    /// </summary>
    public const string AccessLevel0 = nameof(UserRoles.SuperAdmin);

    /// <summary>
    /// Access level only for administration
    /// </summary>
    public const string AccessLevel1 = ConstRoles.AccessLevel0
        + ", " + nameof(UserRoles.Admin);

    /// <summary>
    /// Access level for every staff member
    /// </summary>
    public const string AccessLevel2 = ConstRoles.AccessLevel0
        + ", " + nameof(UserRoles.Admin)
        + ", " + nameof(EducationRoles.Teacher);

    /// <summary>
    /// Access level for every university member
    /// </summary>
    public const string AccessLevel3 = ConstRoles.AccessLevel0
        + ", " + nameof(UserRoles.Admin)
        + ", " + nameof(EducationRoles.Teacher)
        + ", " + nameof(EducationRoles.Student);
}
