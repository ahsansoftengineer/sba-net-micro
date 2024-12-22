using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;
public static partial class SeedData
{
  public static void SeedPlatform(this ModelBuilder builder)
  {
    Console.WriteLine("--> PlatformService Seeding Data ");
    List<Platform> data = new List<Platform>();
    data.AddRange(
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
      });
    builder.Entity<Platform>().HasData(data);
  }
}