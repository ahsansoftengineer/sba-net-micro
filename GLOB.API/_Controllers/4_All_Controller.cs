using GLOB.Domain.Base;

namespace GLOB.API.Controllers.Base;
public abstract class API_4_EntityBaseController<TController, TEntity> 
  : API_3_EntityIdStatusPaginationController<TController, TEntity, DtoSearch, DtoCreate>
    where TController : class
    where TEntity : EntityBase, IEntityAlpha, IEntityStatus// (ID, Status, CreatedAt, UpdatedAt)  IEntityBeta, IEntityBase 
{
  public API_4_EntityBaseController(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  }
}