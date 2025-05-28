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
    var result = await AuthLookupBaseHttpz.Gets<ResponseRecords<ProjectzLookup>>(new()
    {
      Body = new { includes = new List<string>() { "ProjectzLookupBase" } }
    });
    return result.Records.ToExtVMList().Ok();
  }
  // Single, Include
  [HttpPost("{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromBody] DtoRequestGet req)
  {
    var result = await AuthLookupBaseHttpz.Get<ResponseRecord<ProjectzLookup>>(new()
    {
      Resource = Id.ToString(),
      Body = new { Includes = req?.Includes ?? null }
    });
    return result.Record.ToExtVMSingle().Ok();
  }

  [HttpGet]
  public async Task<IActionResult> GetsLookup()
  {
    var result = await AuthLookupBaseHttpz.GetsLookup<ResponseRecord<Dictionary<string, DtoSelect>>>();
    return result.Record.ToExtVMSingle().Ok();
  }
  [HttpPost]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds<string> req)
  {
    var result = await AuthLookupBaseHttpz.GetsByIds<ResponseRecords<ProjectzLookup>>(new()
    {
      Body = new { req.Ids}
    });
    return result.Ok();
  }
  [HttpPost]
  public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds<string> req)
  {
    var result = await AuthLookupBaseHttpz.GetsByIdsLookup<ResponseRecord<Dictionary<string, DtoSelect>>>(new()
    {
      Body = new { req.Ids}
    });
    return result.Record.Ok();
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginate(DtoRequestPage<DtoSearch?> req)
  {
    var result = await AuthLookupBaseHttpz.GetsPaginate<VMPaginate<ProjectzLookup>>(new()
    {
      Body = new
      {
        req.Filter,
        req.Includes,
        req.PageNo,
        req.PageSize
      }
    });
    return result.Ok();
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  {
    var result = await AuthLookupBaseHttpz.GetsPaginateOptions<VMPaginate<DtoSelect>>(new()
    {
      Body = new
      {
        req.Filter,
        req.Includes,
        req.PageNo,
        req.PageSize
      }
    });
    return result.Ok();
  }
}