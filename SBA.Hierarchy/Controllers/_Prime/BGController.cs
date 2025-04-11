using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;

[Route("[controller]")]
[ApiController]
public class BGController : Projectz_Default_Controller<BGController, BG>
{
  public BGController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.BGs;
  }
}