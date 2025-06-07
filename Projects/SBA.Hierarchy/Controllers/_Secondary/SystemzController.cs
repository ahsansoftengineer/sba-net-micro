using GLOB.API.Staticz;
using GLOB.Infra.Base;
using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
public class SystemzController : Project_RDS_Controller<SystemzController, Systemz>
{
  public SystemzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.Systemzs;
  }
  [HttpPost]
  public async Task<IActionResult> GetsPaginate([FromBody] DtoRequestPage<SystemzDtoSearch?> req)
  {
    return await _repo.ToActionGetsPaginate(req);
  }
  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions([FromBody] DtoRequestPage<SystemzDtoSearch?> req)
  {
    return await _repo.ToActionGetsPaginateOptions(req);
  }
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SystemzDtoCreate data)
  {
   
    bool hasParent = _uowProjectz.Orgs.AnyId(data.OrgId);
    if(!hasParent) return _Res.BadRequestzId("OrgId",data.OrgId);

    var result = _mapper.Map<Systemz>(data);
    await _repo.Insert(result);
    await _uowInfra.Save();
    return Ok(result);
   
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] SystemzDtoCreate data)
  {
    if (Id < 1) return _Res.NotFoundId(Id);
    
    var item = await _repo.Get(q => q.Id == Id);

    if (item == null) return _Res.NotFoundId(Id);

    bool hasParent = _uowProjectz.Orgs.AnyId(data.OrgId);
    if(!hasParent) return _Res.BadRequestzId("OrgId",data.OrgId);

    var result = _mapper.Map(data, item);
    _repo.Update(item);
    await _uowInfra.Save();
    return Ok(result);
   
  }
}