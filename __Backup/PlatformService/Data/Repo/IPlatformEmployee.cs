using PlatformService.Models;

namespace PlatformService.Data;
public interface IEmployeeRepo
{
  bool SaveChanges();
  IEnumerable<Employee> GetAllEmployees();
  Employee GetEmployeeById(int Id);
  void CreateEmployee(Employee Employee);
}