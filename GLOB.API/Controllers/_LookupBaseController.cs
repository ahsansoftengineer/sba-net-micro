using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class _LookupBaseController : API_4_Default_Controller<_LookupBaseController, ProjectzLookupBase>
{
  public _LookupBaseController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupBases;
  }
}