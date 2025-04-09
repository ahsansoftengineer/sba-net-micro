using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
[ApiController]
public class TestProjController : ProjectzCommonController<TestProjController, TestProj>
{
  public TestProjController(
    IServiceProvider srvcProvider
    ) : base(srvcProvider)
  {
    _repo = _uow.TestProjs;

  }
}