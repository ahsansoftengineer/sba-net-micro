using GLOB.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace SBA.Proj.Data;
public partial class AppDBContextProj 
{

  public DbSet<TestProj> TestProjs { get; set; }
  // .-*
  public DbSet<Org> Orgs { get; set; }
  public DbSet<BG> BGs { get; set; }
  public DbSet<State> States { get; set; }
  public DbSet<Bank> Banks { get; set; }
  public DbSet<Brand> Brands { get; set; }
  public DbSet<Industry> Industrys { get; set; }
  public DbSet<Profession> Professions { get; set; }

  // *-.
  public DbSet<Systemz> Systemzs { get; set; }
  public DbSet<LE> LEs { get; set; }
  public DbSet<OU> OUs { get; set; }
  public DbSet<SU> SUs { get; set; }
  public DbSet<City> Citys { get; set; }
}
