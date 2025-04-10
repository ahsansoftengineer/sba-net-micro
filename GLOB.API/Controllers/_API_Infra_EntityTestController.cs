using GLOB.API.Controllers.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class _API_Infra_EntityTestController : API_4_Default_Controller<_API_Infra_EntityTestController, API_Infra_EntityTest>
{
  public _API_Infra_EntityTestController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.TestInfras;
  }
}