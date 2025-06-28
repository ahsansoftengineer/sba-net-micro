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
      var data = new
      {
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Create}"
      };

      var param = new RabbitMQParam
      {
        body = data,
        route = new RabbitMQRoute
        {
            Exchange = "auth",
            Queue = "projectz-lookup",
            Key = $"{EP.Create}"
        },
        options = new RabbitMQOptions
        {
            ExchangeDurable = true,
            QueueDurable = true
        }
      };

      _API_RabbitMQ.Pubs(param);
      return data.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }

  }
  [HttpPut("{Id}")]
  public async Task<IActionResult> Update(string Id, [FromBody] ProjectzLookupDtoCreate dto)
  {
    var data = new
    {
      Resource = Id,
      Body = dto,
      Event = $"ProjectzLookupz_{EP.Update}"
    };

    var param = new RabbitMQParam
    {
      body = data,
      route = new RabbitMQRoute
      {
          Exchange = "auth",
          Queue = "projectz-lookup",
          Key = $"{EP.Update}"
      },
      options = new RabbitMQOptions
      {
          ExchangeDurable = true,
          QueueDurable = true
      }
    };

    _API_RabbitMQ.Pubs(param);
    return data.ToExtVMSingle().Ok();

  }

  [HttpDelete("{Id}")]
  public async Task<IActionResult> Delete(string Id)
  {
    var data = new
    {
      Resource = Id,
      Event = $"ProjectzLookupz_{EP.Delete}"
    };

    var param = new RabbitMQParam
    {
      body = data,
      route = new RabbitMQRoute
      {
        Exchange = "auth",
        Queue = "projectz-lookup",
        Key = $"{EP.Delete}"
      },
      options = new RabbitMQOptions
      {
        ExchangeDurable = true,
        QueueDurable = true
      }
    };

    _API_RabbitMQ.Pubs(param);
    return data.ToExtVMSingle().Ok();
    
  }
  
  [HttpPatch("{Id}")]
  public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus dto)
  {
    var data = new
    {
      Resource = Id,
      Body = dto,
      Event = $"ProjectzLookupz_{EP.Status}"
    };

    var param = new RabbitMQParam
    {
      body = data,
      route = new RabbitMQRoute
      {
        Exchange = "auth",
        Queue = "projectz-lookup",
        Key = $"{EP.Status}"
      },
      options = new RabbitMQOptions
      {
        ExchangeDurable = true,
        QueueDurable = true
      }
    };

    _API_RabbitMQ.Pubs(param);
    return data.Ok();
  }
}