using System.Collections.ObjectModel;

namespace FutRammerApi.Shared.Authorization;

public static class FSHRoles
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);
    public const string Supervisor = nameof(Supervisor);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Admin,
        Basic,
        Supervisor
    });

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}