using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
[Route("api/[controller]")]
[ApiController]
public class CommonController<TController, TEntity> : BaseController<
    TController, 
    TEntity, 
    CommonDtoSearch, 
    CommonDto, 
    CommonDtoCreate>
    where TController : class
    where TEntity : BaseEntity
{
  public CommonController(
    ILogger<TController> logger,
    IMapper mapper,
    IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
  {

  }
}