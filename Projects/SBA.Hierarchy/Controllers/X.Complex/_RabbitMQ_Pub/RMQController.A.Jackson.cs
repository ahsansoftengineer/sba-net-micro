using GLOB.API.Config.Extz;
using GLOB.API.Controllers.Base;
using GLOB.API.Clientz;
using GLOB.API.Staticz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Utils.Paginate.Extz;
using Microsoft.AspNetCore.Mvc;
using GLOB.Infra.Enumz;
using GLOB.Infra.Utils.Attributez;

namespace SBA.Auth.Controllers;

public partial class _RabbitMQController : API_1_ErrorController<_RabbitMQController>
{
  private readonly MsgBusPub RabbitMQ_Name;
  public _RabbitMQController(IServiceProvider sp) : base(sp)
  {
    RabbitMQ_Name = sp.GetSrvc<MsgBusPub>();
    _API_RabbitMQ = sp.GetSrvc<API_RabbitMQ>();

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
        Event = $"ProjectzLookupz_{EP.Create}"
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