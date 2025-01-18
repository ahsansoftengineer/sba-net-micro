using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Data;
public static partial class SeedData
{
  // public static void SeedEmployee(this AppDBContext context)
  // {
  //   if(!context.Employees.Any(x => x.ID > 0))
  //   {
  //     Console.WriteLine("--> EmployeeService Seeding Data ");
  //     context.Employees.AddRange(DataEmployee);
  //     context.SaveChanges();
  //   }
  // }
  // public static void SeedEmployee(this ModelBuilder builder)
  // {
  //   Console.WriteLine("--> EmployeeService Seeding Data");
  //   builder.Entity<Employee>().HasData(DataEmployee);
  // }
  // public static List<Employee> DataEmployee = [
  //   new Employee()
  //   {
  //     ID = 1,
  //     Name = "Ahsan",
  //     Gender = "Male",
  //   },
  //   new Employee()
  //   {
  //     ID = 2,
  //     Name = "Asim",
  //     Gender = "Male",
  //   },
  //   new Employee()
  //   {
  //     ID = 3,
  //     Name = "Sumaya",
  //     Gender = "Female",
  //   },
  // ];
}