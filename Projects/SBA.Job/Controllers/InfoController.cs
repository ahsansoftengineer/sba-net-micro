
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
  public async Task<IActionResult> SendEmail([FromBody] bool isSuccess)
  {
    if (!isSuccess)
    return "Failed to Send Email".Ok();
      BackgroundJob.Enqueue<SrvcInfo>(x => x.SendEmail());
    return "Email Sent Successfully".Ok();
    
  }

  
}