using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Hierarchy.App;

namespace SBA.Hierarchy.Controllers.Base;
public abstract partial class BasezController<TController, TEntity, DtoResponse>
    : BaseController<TController, TEntity, DtoResponse>
  where TController : class
  where TEntity : BaseEntity
  where DtoResponse : class
{
  protected IUOW uOW = null;
  public BasezController(ILogger<TController> logger, IMapper mapper, IUOW uow) : 
    base(logger, mapper, uow)
  {
    uOW = uow;
  }
}