using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class _LookupzBaseController : API_4_Default_Controller<_LookupzBaseController, ProjectzLookupzBase>
{
  public _LookupzBaseController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupzBases;
  }
}