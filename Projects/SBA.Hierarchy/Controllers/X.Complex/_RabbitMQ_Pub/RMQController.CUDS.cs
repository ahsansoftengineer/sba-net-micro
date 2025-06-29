using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

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

public partial class __RabbitMQController 
{
  private readonly Projectz_RabbitMQ _Projectz_RabbitMQ;

  [HttpPost] [NoCache]
  public async Task<IActionResult> Createz([FromBody] ProjectzLookupDtoCreate dto)
  {
    // dto.Status = Status.Active;
    try
    {
      var route = new RabbitMQRoute(MQ_Exch.Auth, Controllerz.ProjectzLookup)
      {
        Typez = ExchangeType.Direct,
        Key = EP.Create
      };
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Body = dto,
          Event = $"ProjectzLookup_{route.Key}"
        },
        route = route 
      };
      _Projectz_RabbitMQ.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {route.Key}");
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
    try
    {
      Route.Key = EP.Update;
      var param = new RabbitMQParam
      {
        payload = new()
        {
          Resource = Id,
          Body = dto,
          Event = $"ProjectzLookup_{Route.Key}"
        },
        route = Route
      };

      _Projectz_RabbitMQ.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
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
          Event = $"ProjectzLookup_{Route.Key}"
        },
        route = Route
      };

      _Projectz_RabbitMQ.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
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
          Event = $"ProjectzLookup_{Route.Key}"
        },
        route = Route
      };

      _Projectz_RabbitMQ.Pubs(param);
      Console.WriteLine($"--> RabbitMQ : CRUD - Pub - {Route.Key}");
      return param.payload.Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }
    
  }
}