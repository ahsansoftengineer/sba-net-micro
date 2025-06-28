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

public partial class _RabbitMQController 
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
        route = new()
        {
          Exchange = "auth",
          Queue = "projectz-lookup",
          Key = $"{EP.Create}"
        },
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
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Update}"
      },
      route = new()
      {
        Exchange = "auth",
        Queue = "projectz-lookup",
        Key = $"{EP.Update}"
      }
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.ToExtVMSingle().Ok();

  }

  [HttpDelete("{Id}")] [NoCache]
  public async Task<IActionResult> Delete(string Id)
  {
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Event = $"ProjectzLookupz_{EP.Delete}"
      },
      route = new()
      {
        Exchange = "auth",
        Queue = "projectz-lookup",
        Key = $"{EP.Delete}"
      }
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.ToExtVMSingle().Ok();
    
  }
  
  [HttpPatch("{Id}")] [NoCache]
  public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus dto)
  {
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Status}"
      },
      route = new()
      {
        Exchange = "auth",
        Queue = "projectz-lookup",
        Key = $"{EP.Status}"
      }
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.Ok();
  }
}