using Microsoft.AspNetCore.Mvc;

using GLOB.API.Config.Extz;
using GLOB.API.Controllers.Base;
using GLOB.API.Clientz;
using GLOB.API.Staticz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Utils.Paginate.Extz;
using GLOB.Infra.Enumz;
using GLOB.Infra.Utils.Attributez;

using SBA.Projectz.Clientz;

namespace SBA.Auth.Controllers;

public partial class __RabbitMQController : API_1_ErrorController<__RabbitMQController>
{
  private readonly MsgBusPub RabbitMQ_Name;
  public RabbitMQRoute Route = null;
  public __RabbitMQController(IServiceProvider sp) : base(sp)
  {
    RabbitMQ_Name = sp.GetSrvc<MsgBusPub>();
    _Projectz_RabbitMQ = sp.GetSrvc<Projectz_RabbitMQ>();
    Route = new(MQ_Exch.Auth, Controllerz.Auth.ProjectzLookup);
  }

  [HttpPost] [NoCache]
  public async Task<IActionResult> Create([FromBody] ProjectzLookupDtoCreate model)
  {
    try
    {
      var data = new
      {
        model.Name,
        model.Code,
        model.Desc,
        model.ProjectzLookupBaseId,
        Status.Active,
        Event = $"ProjectzLookup_{EP.Create}"
      };
      RabbitMQ_Name.Publish(data);
      return data.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }

  }
}