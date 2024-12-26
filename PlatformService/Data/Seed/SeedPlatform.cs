using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;
public static partial class SeedData
{
  public static void SeedPlatform(this AppDBContext context)
  {
    if(!context.Platforms.Any(x => x.ID > 0))
    {
      Console.WriteLine("--> PlatformService Seeding Data ");
      context.Platforms.AddRange(DataPlatform);
      context.SaveChanges();
    }
  }
  public static void SeedPlatform(this ModelBuilder builder)
  {
    Console.WriteLine("--> PlatformService Seeding Data");
    builder.Entity<Platform>().HasData(DataPlatform);
  }
  public static List<Platform> DataPlatform = [
    new Platform()
    {
      ID = 1,
      Name = "Dot Net",
      Publisher = "Microsoft",
      Cost = "Free"
    },
    new Platform()
    {
      ID = 2,
      Name = "SQL Server Express",
      Publisher = "Microsoft",
      Cost = "Free"
    },
    new Platform()
    {
      ID = 3,
      Name = "Kubernetes",
      Publisher = "Cloud Native Computing Foundation",
      Cost = "Free"
    },
  ];
}