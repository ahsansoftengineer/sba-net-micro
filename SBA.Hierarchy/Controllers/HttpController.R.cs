using GLOB.API.Http;
using GLOB.API.Staticz;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AuthLookupBaseHttpController 
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    var result = await AuthLookupBaseHttpz.Gets<ResponseRecords>(
      new HttpReq {
        // Host = "http://localhost:5802",
        // Srvc = "api/auth/v1",
        // Controller = "lookup-base",
        Action =  EP.Gets,
        // Resource = "1",
        // Query = new { Id = 101 },
        // Body = new List<string>() { "Lookup" }

      }
    );
    return result.Ok();
  }
  // // List, Group
  // [HttpGet]
  // public async Task<IActionResult> GetsLookup()
  // {
  // }
  // [HttpPost("{Id}")]
  // public async Task<IActionResult> Get(string Id)
  // {
  // }
  // // List, Filter By Ids
  // [HttpPost]
  // public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds<string> req)
  // {
  // }
  // [HttpPost]
  // public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds<string> req)
  // {
  // }
  
  // [HttpPost]
  // public async Task<IActionResult> GetsPaginate(DtoRequestPage<DtoSearch?> req)
  // {
  // }

  // [HttpPost]
  // public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  // {
  // }
}