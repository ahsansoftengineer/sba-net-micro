using PlatformService.Models;

namespace PlatformService.Data;
public class EmployeeRepo : IEmployeeRepo
{
  private readonly AppDBContext _context;

  public EmployeeRepo(AppDBContext context)
  {
    _context = context;
  }
  public void CreateEmployee(Employee Employee)
  {
    if(Employee == null)
    {
      throw new ArgumentNullException(nameof(Employee));
    }
    _context.Employees.Add(Employee);
  }

  public IEnumerable<Employee> GetAllEmployees()
  {
    return _context.Employees.ToList();
  }

  public Employee GetEmployeeById(int ID)
  {
    return _context.Employees.FirstOrDefault(x => x.ID == ID);
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }
}