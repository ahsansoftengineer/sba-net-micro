using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using GLOB.Infra.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GLOB.API.Staticz;

public static partial class _Actionz
{
  public static async Task<IActionResult> ToActionGets<T>(this IRepoGenericz<T> repo, List<string>? Include)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.Gets(Include: Include);
      var result = list.ToExtVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGets));
    }
  }
  public static async Task<IActionResult> ToActionGetsLookup<T>(this IRepoGenericz<T> repo)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.GetDBSet()
        .Select(x => new {x.Id, x.Name})
        .ToDictionaryAsync(x => x.Id, y => new {y.Id, y.Name});
      return Ok(list);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGetsLookup));
    }
  }
}