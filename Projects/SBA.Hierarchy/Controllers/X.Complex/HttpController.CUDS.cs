using GLOB.API.Controllers.Base;
using GLOB.API.Http;
using GLOB.API.Staticz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AuthLookupBaseHttpController : API_1_ErrorController<AuthLookupBaseHttpController>
{
  public readonly Httpz AuthLookupBaseHttpz;
  public AuthLookupBaseHttpController(IServiceProvider srvc): base(srvc) 
  {
    // string  gatewayUrl = _config.GetValueStr("URLzGateway"); 
    AuthLookupBaseHttpz = new Httpz(_appSettings.SrvcHttp.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
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