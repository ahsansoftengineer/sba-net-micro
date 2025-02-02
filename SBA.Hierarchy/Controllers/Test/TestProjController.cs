using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.Infra;

namespace SBA.Hierarchy.Controllers.Test;
[Route("api/Hierarchy/Test/[controller]")]
[ApiController]
public class TestProjController : CommonController<TestProjController, TestProj>
{
  public TestProjController(
    ILogger<TestProjController> logger,
    IMapper mapper,
    UOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.TestProjs;

  }
}