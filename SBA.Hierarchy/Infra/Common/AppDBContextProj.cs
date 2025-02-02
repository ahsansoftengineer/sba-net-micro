using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public partial class AppDBContextProj 
{
  public DbSet<TestProj> TestProjs { get; set; }
}
