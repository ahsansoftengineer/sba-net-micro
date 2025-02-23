using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class AppDBContextProj 
{

  public DbSet<TestProj> TestProjs { get; set; }
}
