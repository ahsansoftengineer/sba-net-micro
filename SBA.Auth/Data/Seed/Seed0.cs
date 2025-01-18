using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Data;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    // mb.SeedPlatform();
    // mb.SeedEmployee();
  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContext? context = srvcScp.ServiceProvider.GetService<AppDBContext>();
      if (context != null)
      {
        Console.WriteLine("--> Applying Migrations Not Development");
        context.Database.Migrate();

        {
          // context.SeedEmployee();
        }
      }
    }
  }
}