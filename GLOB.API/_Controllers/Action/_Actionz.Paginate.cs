using GLOB.Domain.Base;
using GLOB.Infra.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Staticz;

public static partial class _Actionz
{
  public async static Task<IActionResult> ToActionGetsPaginate<TEntity, TDtoSearch>(this IRepoGenericz<TEntity> repo,  DtoRequestPage<TDtoSearch?> req)
    where TEntity : class, IEntityAlpha
    where TDtoSearch: class, IDtoSearch
  {
      var data = await repo.GetsPaginate(req);
      return data.Ok();
  }

  public async static Task<IActionResult> ToActionGetsPaginateOptions<TEntity, TDtoSearch>(this IRepoGenericz<TEntity> repo, DtoRequestPageOption<TDtoSearch?> req)
    where TEntity : class, IEntityAlpha
    where TDtoSearch: class, IDtoSearch
  {
      var data = await repo.GetsPaginateOptions(req);
      return data.Ok();
  }


}