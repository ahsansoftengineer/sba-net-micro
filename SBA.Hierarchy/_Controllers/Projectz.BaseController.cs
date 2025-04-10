using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;
public abstract partial class ProjectzBaseController<TController, TEntity>
    : API_2_RDS_Controller<TController, TEntity>
  where TController : class
  where TEntity : EntityBase
{
  protected readonly IUOW _uow;
  public ProjectzBaseController(IServiceProvider srvcProvider) : 
    base(srvcProvider)
  {
    _uow = GetSrvc<IUOW>();
  }
}