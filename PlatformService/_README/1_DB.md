1. Model
```csharp
namespace PlatformService.Models;
public class Platform
{
  [Key]
  [Required]
  public int ID { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Publisher { get; set; }
  [Required]
  public string Cost { get; set; }
}
```
2. App SbPlatform Context
```csharp
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;
public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
  {
    
  }
  public DbSet<Platform> Platforms { get; set; }
}
```
3. Seed Data
```csharp
public static class PrepDb
{
  public static void PrepPopulation(IApplicationBuilder app)
  {
    using(var srvcScope = app.ApplicationServices.CreateScope())
    {
      SeedData(srvcScope.ServiceProvider.GetService<AppDBContext>());
    }
  }
  private static void SeedData(AppDBContext context)
  {
    if(!context.Platforms.Any())
    {
      Console.WriteLine("--> PlatformService Seeding Data ");
      context.Platforms.AddRange(
        new Platform()
        {
          Name = "Dot Net",
          Publisher = "Microsoft",
          Cost = "Free"
        },
        new Platform()
        {
          Name = "SQL Server Express",
          Publisher = "Microsoft",
          Cost = "Free"
        },
        new Platform()
        {
          Name = "Kubernetes",
          Publisher = "Cloud Native Computing Foundation",
          Cost = "Free"
        }
      );
      context.SaveChanges();
    }
    else 
    {
      Console.WriteLine("--> We already have data");
    }

  }
}
// Add the Below Code in Configure Method at the end
// PrepDb.PrepPopulation(app);
```
4. Repo
```csharp
namespace PlatformService.Data;
public interface IPlatformRepo
{
  bool SaveChanges();
  IEnumerable<Platform> GetAllPlatforms();
  Platform GetPlatformById(int id);
  void CreatePlatform(Platform platform);
}

public class PlatformRepo : IPlatformRepo
{
  private readonly AppDBContext _context;

  public PlatformRepo(AppDBContext context)
  {
    _context = context;
  }
  public void CreatePlatform(Platform platform)
  {
    if(platform == null)
    {
      throw new ArgumentNullException(nameof(platform));
    }
    _context.Platforms.Add(platform);
  }

  public IEnumerable<Platform> GetAllPlatforms()
  {
    return _context.Platforms.ToList();
  }

  public Platform GetPlatformById(int ID)
  {
    return _context.Platforms.FirstOrDefault(x => x.ID == ID);
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }
}
```
5. Registering to Startup
```csharp
public void ConfigureServices(IServiceCollection srvc)
{
  srvc.AddDbContext<AppDBContext>(opt => {
    opt.UseInMemoryDatabase("InMem");
  });
  srvc.AddControllers(); 
  srvc.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
  srvc.AddTransient<IPlatformRepo, PlatformRepo>();
}
```