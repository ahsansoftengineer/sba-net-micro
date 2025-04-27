using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using GLOB.Infra.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GLOB.API.Staticz;

public static partial class _Actionz
{
 
  public static async Task<IActionResult> ToActionGet<T>(this IRepoGenericz<T> repo, int Id, List<string>? Include)
    where T : class, IEntityAlpha
  {
    try
    {
      var single = await repo.Get(Id, Include);
      if(single == null) return _Res.NotFoundId(Id);
      
      var result = single.ToExtVMSingle();
      return Ok(result);
    }
    catch(Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGet));
    }
  }
  public static async Task<IActionResult> ToActionGetsByIds<T>(this IRepoGenericz<T> repo, List<int>? Ids)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.Gets((x)=> Ids.Contains(x.Id));
      var result = list.ToExtVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGetsByIds));
    }
  }
  public static async Task<IActionResult> ToActionGetsByIdsGroup<T>(this IRepoGenericz<T> repo, List<int>? Ids)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.GetDBSet().Where((x)=> Ids.Contains(x.Id)).GroupBy(x => x.Id).ToListAsync();
      var result = list.ToExtVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(ToActionGetsByIdsGroup));
    }
  }
}