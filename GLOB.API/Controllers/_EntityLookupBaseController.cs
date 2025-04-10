using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class _EntityLookupBaseController : API_4_EntityBaseController<_EntityLookupBaseController, ProjectzEntityLookupBase>
{
  public _EntityLookupBaseController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzEntityLookupBases;
  }
}