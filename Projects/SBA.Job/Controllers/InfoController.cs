
using GLOB.API.Staticz;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Srvc;

namespace SBA.Job.Controllers;

public class InfoController : API_1_InjectorController<InfoController>
{
  public InfoController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
  }

  [HttpPost]
  public async Task<IActionResult> BulkCreateProjectzLookup([FromBody] bool isSuccess)
  {
    if (!isSuccess)
      return "Failed to Send Email".Ok();

    BackgroundJob.Enqueue<SrvcProjectzLookup>(x => x.BulkCreate());
    return "Email Sent Successfully".Ok();
  }

  [HttpPost]
  public async Task<IActionResult> BulkUpdateProjectzLookup([FromBody] bool isSuccess)
  {
    if (!isSuccess)
      return "Failed to Send Email".Ok();

    BackgroundJob.Enqueue<SrvcProjectzLookup>(x => x.BulkUpdate());
    return "Email Sent Successfully".Ok();
  }
  
    [HttpPost]
  public async Task<IActionResult> UpdateDBProjectzLookup([FromBody] bool isSuccess)
  {
    if (!isSuccess)
      return "Failed to Send Email".Ok();

     RecurringJob.AddOrUpdate<SrvcProjectzLookup>(
      recurringJobId: "job-notify-send-email",
      methodCall: x => x.UpdateDatabase(),
      cronExpression: Cron.Minutely, // Every 10 Secs
      queue: "queue-short-time",
      options: new RecurringJobOptions
      {
        TimeZone = TimeZoneInfo.Local,
      }
    );
    return "Email Sent Successfully".Ok();
  }
}