using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Common;

namespace GLOB.API.Controllers.Base;
public abstract class CommonController<TController, TEntity> 
  : BetaController<TController, TEntity, BaseDtoSearchFull, BaseDtoFull, BaseDtoCreate>
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