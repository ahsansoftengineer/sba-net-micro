using GLOB.API.Http;
using GLOB.API.Staticz;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AuthLookupBaseHttpController 
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    var result = await AuthLookupBaseHttpz.Gets<ResponseRecords<ProjectzLookup>>(new () {
      Action =  EP.Gets,
      Body =  new { includes = new List<string>() { "ProjectzLookupBase"} }
    });
    var resultz =  result.Records;
    return resultz.Ok();
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