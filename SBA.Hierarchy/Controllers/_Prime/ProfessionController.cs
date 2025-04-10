using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class ProfessionController : Projectz_Default_Controller<ProfessionController, Profession>
{
  public ProfessionController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.Professions;
  }
}