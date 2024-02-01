namespace SIS2Server.Core.Constants;

public static class Roles
{
    public enum Definitions
    {
        User,
        SuperAdmin,
        Admin,
        Rector,
        Dean,
        Teacher,
        Student,
    }

    /// <summary>
    /// Access level for every university member
    /// </summary>
    public const string AccessLevel1 = nameof(Definitions.SuperAdmin)
        + ", " + nameof(Definitions.Admin)
        + ", " + nameof(Definitions.Rector)
        + ", " + nameof(Definitions.Dean)
        + ", " + nameof(Definitions.Teacher)
        + ", " + nameof(Definitions.Student);

    /// <summary>
    /// Access level for every staff member
    /// </summary>
    public const string AccessLevel2 = nameof(Definitions.SuperAdmin)
        + ", " + nameof(Definitions.Admin)
        + ", " + nameof(Definitions.Rector)
        + ", " + nameof(Definitions.Dean)
        + ", " + nameof(Definitions.Teacher);
}
