using GLOB.API.Config.Extz;
using GLOB.API.Controllers.Base;
using GLOB.API.Clientz;
using GLOB.API.Staticz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Utils.Paginate.Extz;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class _RabbitMQController : API_1_ErrorController<_RabbitMQController>
{
  public readonly Httpz AuthLookupBaseHttpz;
  public _RabbitMQController(IServiceProvider sp) : base(sp)
  {
    // string  gatewayUrl = _config.GetValueStr("URLzGateway"); 
    // AuthLookupBaseHttpz = new Httpz(_appSettings.SrvcHttp.Auth, Srvc.Auth, Controllerz.ProjectzLookup);
    AuthLookupBaseHttpz = sp.GetSrvc<UOW_Httpz>().AuthLookupBaseHttpz;
  }
 
  // [HttpPost]
  // public async Task<IActionResult> Create([FromBody] RegisterDto model)
  // {
  // }
  // [HttpPut("{Id}")]
  // public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserDto data)
  // {
  // }

  [HttpDelete("{Id}")]
  public async Task<IActionResult> Delete(string Id)
  {
    var result = await AuthLookupBaseHttpz.Delete(new()
    {
      Resource = Id,
    });
    return result.Ok();
  }
  [HttpPatch("{Id}")]
  public async Task<IActionResult> Status(string Id, [FromBody] DtoRequestStatus req)
  {
    var result = await AuthLookupBaseHttpz.Status<ResponseRecord<ProjectzLookup>>(new()
    {
      Resource = Id,
      Body = req 
    });
    return result.Ok();
  }
}