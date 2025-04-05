using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;
public abstract partial class BasezController<TController, TEntity, DtoResponse>
    : BaseController<TController, TEntity, DtoResponse>
  where TController : class
  where TEntity : EntityBase
  where DtoResponse : class
{
  protected readonly IUOW _uow;
  public BasezController(IServiceProvider srvcProvider) : 
    base(srvcProvider)
  {
    _uow = GetSrvc<IUOW>();
  }
}