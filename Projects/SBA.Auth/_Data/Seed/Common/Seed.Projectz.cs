using GLOB.Infra.Data.Auth;


namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    "-->  ModelBuilder --> Auth -> SeedProjectz".Print("[EF Core]");
    mb.SeedInfraIdentity(); // base.OnModelCreating

  }
  // Prod (When Running Migration throw Automation)
  public static async Task Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    { 
      var provider = srvcScp.ServiceProvider;
      DBCtxProjectz? context = provider.GetSrvc<DBCtxProjectz>();
      if (context != null)
      {
        "--> Auth -> Applying Migrations AppBuilder".Print("[EF Core]");
        
        // context.Database.Migrate();
        {
          await app.SeedInfraIdentity();
        }
      }
    }
  }

}