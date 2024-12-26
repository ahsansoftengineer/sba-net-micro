using PlatformService.Models;

namespace PlatformService.Data;
public static partial class SeedData
{
  public static void SeedPlatform(this AppDBContext context)
  {
    List<Platform> data =
    [
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
      },
    ];
    if(!context.Platforms.Any(x => x.ID > 0))
    {
      Console.WriteLine("--> PlatformService Seeding Data ");
      context.Platforms.AddRange(data);
      context.SaveChanges();
    }
  }
}