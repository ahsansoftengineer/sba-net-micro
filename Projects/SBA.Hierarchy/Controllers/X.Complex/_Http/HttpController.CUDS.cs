using GLOB.API.Config.Extz;
using GLOB.API.Controllers.Base;
using GLOB.API.Clientz;
using GLOB.API.Staticz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Utils.Paginate.Extz;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class _HttpController : API_1_ErrorController<_HttpController>
{
  public readonly Httpz Httpz_AuthLookup;
  public _HttpController(IServiceProvider sp) : base(sp)
  {
    // string  gatewayUrl = _config.GetValueStr("URLzGateway"); 
    // Httpz_AuthLookup = new Httpz(_Option_App.SrvcHttp.Auth, Srvc.Auth, Controllerz.ProjectzLookup);
    Httpz_AuthLookup = sp.GetSrvc<UOW_Httpz>().Httpz_AuthLookup;
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
    var result = await Httpz_AuthLookup.Delete(new()
    {
      Resource = Id,
    });
    return result.Ok();
  }
  [HttpPatch("{Id}")]
  public async Task<IActionResult> UpdateStatus(string Id, [FromBody] DtoRequestStatus req)
  {
    var result = await Httpz_AuthLookup.Status<ResponseRecord<ProjectzLookup>>(new()
    {
      Resource = Id,
      Body = req 
    });
    return result.Ok();
  }
}