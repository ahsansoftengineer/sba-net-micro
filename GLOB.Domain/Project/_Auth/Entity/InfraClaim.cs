namespace GLOB.Domain.Auth.Enumz;
public class UserPermission
{

    public int Id { get; set; }
    public string RoleId { get; set; }
    public string Entity { get; set; } // Example: "Employee", "Payroll"
    public Permission Permissions { get; set; }
}
