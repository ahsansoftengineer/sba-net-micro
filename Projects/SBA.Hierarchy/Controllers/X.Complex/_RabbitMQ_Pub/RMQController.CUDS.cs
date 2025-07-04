using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

using GLOB.API.Clientz;
using GLOB.API.Staticz;
using GLOB.Infra.Utils.Paginate.Extz;
using GLOB.Infra.Utils.Attributez;



namespace SBA.Auth.Controllers;

public partial class __RabbitMQController 
{

  [HttpPost] [NoCache]
  public async Task<IActionResult> Createz([FromBody] ProjectzLookupDtoCreate dto)
  {
    // dto.Status = Status.Active;
    try
    {
      var route = new RabbitMQRoute(MQ_Exch.Auth, Controllerz.Auth.ProjectzLookup)
      {
        Typez = ExchangeType.Direct,
        Key = EP.Create
      };
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Body = dto,
        },
        route = route 
      };
      _rmqPubs.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {route.Key}");
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> [Rabbit MQ] Error : {ex.Message}".ToExtVMSingle().Ok();
    }

  }
  [HttpPut("{Id}")] [NoCache]
  public async Task<IActionResult> Update(string Id, [FromBody] ProjectzLookupDtoCreate dto)
  {
    try
    {
      Route.Key = EP.Update;
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Resource = Id,
          Body = dto,
        },
        route = Route
      };

      _rmqPubs.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> [Rabbit MQ] Error : {ex.Message}".ToExtVMSingle().Ok();
    }
    
  }

  [HttpDelete("{Id}")] [NoCache]
  public async Task<IActionResult> Delete(string Id)
  {
    try
    {
      Route.Key = EP.Delete;
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Resource = Id,
        },
        route = Route
      };

      _rmqPubs.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> [Rabbit MQ] Error : {ex.Message}".ToExtVMSingle().Ok();
    }
    
  }
  
  [HttpPatch("{Id}")] [NoCache]
  public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus dto)
  {
    try
    {
      Route.Key = EP.Status;
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Resource = Id,
          Body = dto,
        },
        route = Route
      };

      _rmqPubs.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> [Rabbit MQ] Error : {ex.Message}".ToExtVMSingle().Ok();
    }
    
  }
}