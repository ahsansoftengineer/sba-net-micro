using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public static partial class Seeder
{
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContext? context = 
      srvcScp.ServiceProvider.GetService<AppDBContext>();
      if (context != null){
        Console.WriteLine("--> Applying Migrations");
        context.Database.Migrate();
        context.SeedPlatform();
      }
    }
  }
}