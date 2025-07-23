

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    "ModelBuilder --> Hierarchy -> SeedProjectz".Print("[EF Core]");
    // .-*

    // *-.

  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCtxProjectz? context = srvcScp.ServiceProvider.GetSrvc<DBCtxProjectz>();
      if (context != null)
      {
        "--> Hierarchy -> Applying Migrations AppBuilder".Print("[EF Core]");
        // context.Database.Migrate();
        {
          // .-*

          // *-.
        }
      }
    }
  }

}