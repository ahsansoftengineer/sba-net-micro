using Hangfire;
using SBA.Projectz.Srvc;

public static partial class DI_Projectz
{
  // https://freeformatter.com/cron-expression-generator-quartz.html
  public static void Call_Hangfire_Recuring_Jobs(this IApplicationBuilder app)
  {
    // 0/10 0 0 ? * * * -> Every 10 Secs
    // 0 * * ? * * -> Every Minutes
    RecurringJob.AddOrUpdate<SrvcInfo>(opt => opt.SendEmail(), "0 * * ? * *");
    RecurringJob.AddOrUpdate<SrvcProjectzLookup>(opt => opt.BulkCreate(), "0 * * ? * *");
  }
}