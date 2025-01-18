using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Data;
public partial class AppDBContext : DbContext
{
  // NOTE:
  // DB Set is not the Compulsory Part to work with Entity
  // You can Can get DbSet.Get<Entity>() to Work
  // It is because of Model Builder

  // Prime
  // public DbSet<Platform> Platforms { get; set; }
  // public DbSet<Employee> Employees { get; set; }
}