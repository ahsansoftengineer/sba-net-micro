using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCntxtProj 
{

  public DbSet<TestProj> TestProjs { get; set; }
}
