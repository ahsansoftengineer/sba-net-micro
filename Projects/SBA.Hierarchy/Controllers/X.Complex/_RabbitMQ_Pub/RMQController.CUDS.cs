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
  private readonly API_RabbitMQ API_RabbitMQ;

  [HttpPost] [NoCache]
  public async Task<IActionResult> Createz([FromBody] ProjectzLookupDtoCreate model)
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

      var param = new RabbitMQParam
      {
        body = data,
        route = new RabbitMQRoute
        {
            Exchange = "ex-sample",
            Queue = "q-sample",
            Key = "sample.key"
        },
        options = new RabbitMQOptions
        {
            ExchangeDurable = true,
            QueueDurable = true
        }
      };

      API_RabbitMQ.Pubs(param);
      return data.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      // return ex.Ok();
      return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }

  }
  // [HttpPut("{Id}")]
  // public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserDto data)
  // {
  // }

  // [HttpDelete("{Id}")]
  // public async Task<IActionResult> Delete(string Id)
  // {
  //   var result = await API_Httpz_AuthLookup.Delete(new()
  //   {
  //     Resource = Id,
  //   });
  //   return result.Ok();
  // }
  
  // [HttpPatch("{Id}")]
  // public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus req)
  // {
  //   var result = await API_Httpz_AuthLookup.Status<ResponseRecord<ProjectzLookup>>(new()
  //   {
  //     Resource = Id,
  //     Body = req
  //   });
  //   return result.Ok();
  // }
}