using AutoMapper;
using GLOB.Domain.Base;
using GLOB.Infra.UOW;

namespace GLOB.API.Controllers.Base;
public abstract class CommonController<TController, TEntity> 
  : BetaController<TController, TEntity, DtoSearch, DtoRead, DtoCreate>
    where TController : class
    where TEntity : EntityBase
{
  public CommonController(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  }
}