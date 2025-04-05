using GLOB.API.Controllers.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class TestInfraController : CommonController<TestInfraController, TestInfra>
{
  public TestInfraController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.TestInfras;
  }
}