using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Hierarchy.Controllers.Test;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class TestProjController : CommonController<TestProjController, TestProj>
{
  public TestProjController(
    ILogger<TestProjController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.TestProjs;

  }
}