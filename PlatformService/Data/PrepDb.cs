using PlatformService.Models;

namespace PlatformService.Data;

#pragma warning disable CS8604 
public static class PrepDb
{
  public static void PrepPopulation(IApplicationBuilder app)
  {
    using(var srvcScope = app.ApplicationServices.CreateScope())
    {
      SeedData(srvcScope.ServiceProvider.GetService<AppDbContext>());
    }
  }
  private static void SeedData(AppDbContext context)
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