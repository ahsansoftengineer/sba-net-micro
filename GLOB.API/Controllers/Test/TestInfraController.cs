using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Apps.Common;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Test;
[Route("api/Test/[controller]")]
[ApiController]
public class TestInfraController : CommonController<TestInfraController, TestInfra>
{
  public TestInfraController(
    ILogger<TestInfraController> logger,
    IMapper mapper,
    IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
  {
    Repo = unitOfWork.TestInfras;

  }
}