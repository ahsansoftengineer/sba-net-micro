using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class BrandController : Projectz_Default_Controller<BrandController, Brand>
{
  public BrandController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.Brands;
  }
}