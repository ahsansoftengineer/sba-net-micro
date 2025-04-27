using GLOB.Domain.Base;
using GLOB.Infra.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Staticz;

public static partial class _Actionz
{
  public async static Task<IActionResult> ToActionGetsPaginate<TEntity, TDtoSearch>(IRepoGenericz<TEntity> repo,  DtoRequestPage<TDtoSearch?> req)
    where TEntity : class, IEntityAlpha
    where TDtoSearch: class, IDtoSearch
  {
    try
    {
      var data = await repo.GetsPaginate(req);
      return Ok(data);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGetsPaginate));
    }
  }

  public async static Task<IActionResult> ToActionGetsPaginateOptions<TEntity, TDtoSearch>(IRepoGenericz<TEntity> repo, DtoRequestPageOption<TDtoSearch?> req)
    where TEntity : class, IEntityAlpha
    where TDtoSearch: class, IDtoSearch
  {
    try
    {
      var data = await repo.GetsPaginateOptions(req);
      return Ok(data);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGetsPaginateOptions));
    }
  }


}