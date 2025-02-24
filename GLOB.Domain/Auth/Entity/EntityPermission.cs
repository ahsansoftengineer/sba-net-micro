namespace GLOB.Domain.Auth;
public class EntityPermission
{
    public int Id { get; set; }
    public string RoleId { get; set; }
    public string Entity { get; set; } // Example: "Employee", "Payroll"
    public Permission Permissions { get; set; }
}
