

namespace SBA.Projectz.Data;
public static partial class SeedzProjectz
{
  // Dev (When Running Migration throw CLI)
  public static void SeedProjectz(this ModelBuilder mb)
  {
    "ModelBuilder --> Job -> SeedProjectz".Print("EF Core");
    // .-*

    // *-.

  }
  // Prod (When Running Migration throw Automation)
  public static void SeedProjectz(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCtxProjectz? context = srvcScp.ServiceProvider.GetSrvc<DBCtxProjectz>();
      if (context != null)
      {
        "--> Job -> Applying Migrations AppBuilder".Print("EF Core");
        context.Database.EnsureCreated();
        // context.Database.Migrate();
        {
          // .-*

          // *-.
        }
      }
    }
  }

}