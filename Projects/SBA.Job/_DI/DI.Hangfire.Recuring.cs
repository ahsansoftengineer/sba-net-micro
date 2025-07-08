using Hangfire;
using SBA.Projectz.Srvc;

public static partial class DI_Projectz
{
  public static void Add_Hangfire_Recuring_Srvc(this IApplicationBuilder app)
  {
    RecurringJob.AddOrUpdate<SrvcInfo>(opt => opt.SendEmail(), "");
    RecurringJob.AddOrUpdate<SrvcProjectzLookup>(opt => opt.BulkCreate(), "");
  }
}