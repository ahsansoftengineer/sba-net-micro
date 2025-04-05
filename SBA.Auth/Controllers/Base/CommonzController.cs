using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;

public abstract class CommonzController<TController, TEntity>
  : CommonController<TController, TEntity>
    where TController : class
    where TEntity : EntityBase
{
  protected readonly IUOW _uow;
  public CommonzController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _uow = GetSrvc<IUOW>();
  }
}