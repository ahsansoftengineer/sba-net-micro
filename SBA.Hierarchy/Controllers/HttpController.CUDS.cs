using GLOB.API.Http;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AuthLookupBaseHttpController
{
  public readonly Httpz AuthLookupBaseHttpz;
  public AuthLookupBaseHttpController() 
  {
    AuthLookupBaseHttpz = new Httpz("http://localhost:5802", "api/auth/v1", "lookup-base") ;
  }
 
  // [HttpPost]
  // public async Task<IActionResult> Create([FromBody] RegisterDto model)
  // {
  // }
  // [HttpPut("{Id}")]
  // public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserDto data)
  // {
  // }

  // [HttpDelete("{Id}")]
  // public async Task<IActionResult> Delete(string Id)
  // {
  // }
  // [HttpPatch("{Id}")]
  // public async Task<IActionResult> Status(string Id, [FromBody] DtoRequestStatus req)
  // {
  // }
}