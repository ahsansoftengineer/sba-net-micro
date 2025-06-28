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

public partial class __RabbitMQController 
{
  private readonly API_RabbitMQ _API_RabbitMQ;

  [HttpPost] [NoCache]
  public async Task<IActionResult> Createz([FromBody] ProjectzLookupDtoCreate dto)
  {
    // dto.Status = Status.Active;
    try
    {
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Body = dto,
          Event = $"ProjectzLookupz_{EP.Create}"
        },
        route = new(MQ_Exch.Auth, Controllerz.ProjectzLookup,  EP.Create),
        options = new()
        {
          ExchangeDurable = true,
          QueueDurable = true
        }
      };
      _API_RabbitMQ.Pubs(param);
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }

  }
  [HttpPut("{Id}")] [NoCache]
  public async Task<IActionResult> Update(string Id, [FromBody] ProjectzLookupDtoCreate dto)
  {
    Route.Key = EP.Update;
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Update}"
      },
      route = Route
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.ToExtVMSingle().Ok();
  }

  [HttpDelete("{Id}")] [NoCache]
  public async Task<IActionResult> Delete(string Id)
  {
    Route.Key = EP.Delete;
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Event = $"ProjectzLookupz_{EP.Delete}"
      },
      route = Route
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.ToExtVMSingle().Ok();
    
  }
  
  [HttpPatch("{Id}")] [NoCache]
  public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus dto)
  {
    Route.Key = EP.Status;
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Status}"
      },
      route = Route
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.Ok();
  }
}