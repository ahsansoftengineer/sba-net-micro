using GLOB.API.Controllers.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class API_Infra_EntityTestController : CommonController<API_Infra_EntityTestController, API_Infra_EntityTest>
{
  public API_Infra_EntityTestController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.TestInfras;
  }
}