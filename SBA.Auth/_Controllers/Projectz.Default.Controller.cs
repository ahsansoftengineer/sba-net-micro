using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;

public abstract class Projectz_Default_Controller<TController, TEntity>
  : API_4_Default_Controller<TController, TEntity>
    where TController : class
    where TEntity : EntityBase
{
  protected readonly IUOW_Projectz _uow;
  public Projectz_Default_Controller(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _uow = GetSrvc<IUOW_Projectz>();
  }
}