using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;

namespace SBA.Hierarchy.Controllers.Test;
[Route("api/Hierarchy/Test/[controller]")]
[ApiController]
public class SystemzController : CommonController<SystemzController, Systemz>
{
  public SystemzController(
    ILogger<SystemzController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.Systemzs;

  }
}