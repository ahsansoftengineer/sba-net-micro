using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;
public abstract class CommonzController<TController, TEntity> 
  : CommonController<TController, TEntity> 
    where TController : class
    where TEntity : BaseEntity
{
  protected IUOW uOW = null;
  public CommonzController(
    ILogger<TController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    uOW = uow;

  }
}