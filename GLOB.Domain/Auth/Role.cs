namespace GLOB.Domain.Auth;
public class Role
{
    public string Name { get; set; }
    public Permission Permissions { get; set; }

    public Role(string name, Permission permissions)
    {
        Name = name;
        Permissions = permissions;
    }

    public bool HasPermission(Permission permission)
    {
        return (Permissions & permission) == permission;
    }
}
