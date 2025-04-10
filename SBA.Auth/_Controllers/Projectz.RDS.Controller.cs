using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using SBA.Projectz.Data;

namespace SBA.Projectz.Controllers.Base;
public abstract partial class Project_RDS_Controller<TController, TEntity>
    : API_2_RDS_Controller<TController, TEntity>
  where TController : class
  where TEntity : EntityBase
{
  protected readonly IUOW _uow;
  public Project_RDS_Controller(IServiceProvider srvcProvider) : 
    base(srvcProvider)
  {
    _uow = GetSrvc<IUOW>();
  }
}