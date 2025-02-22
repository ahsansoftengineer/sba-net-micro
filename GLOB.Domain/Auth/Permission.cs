namespace GLOB.Domain.Auth;

[Flags]
public enum Permission
{
    None = 0,
    Create = 1 << 0,  // 1
    View = 1 << 1,    // 2
    Update = 1 << 2,  // 4
    Delete = 1 << 3,  // 8
    ChangeStatus = 1 << 4, // 16
    Export = 1 << 5, // 32
    Import = 1 << 6, // 64
    FullAccess = Create | View | Update | Delete | ChangeStatus | Export | Import // 127
}

