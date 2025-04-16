using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using GLOB.Infra.Paginate;
using GLOB.Infra.Repo;
using GLOB.Infra.UOW_Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Staticz;

public static partial class _Actionz
{
  public static OkObjectResult Ok(object obj)
  {
    return new OkObjectResult(obj);
  }
  public static async Task<IActionResult> Getz<T>(this IRepoGenericz<T> repo, int Id, List<string>? Include)
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
      return _Res.CatchException(ex, nameof(Getz));
    }
  }
  public static async Task<IActionResult> GetsByIdsz<T>(this IRepoGenericz<T> repo, List<int>? Ids, List<string>? Includes)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.GetsByIds(Ids, Includes);
      var result = list.ToExtVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Getsz));
    }
  }
  public static async Task<IActionResult> Getsz<T>(this IRepoGenericz<T> repo, List<string>? Include)
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
      return _Res.CatchException(ex, nameof(Getsz));
    }
  }
  
  public static async Task<IActionResult> Deletez<T>(this IRepoGenericz<T> repo, IUOW_Infra uow, int Id)
    where T : class, IEntityAlpha
  {
    try
    {
      if (Id < 1) return _Res.NotFoundId(Id);
      var item = await repo.Get(Id);

      if (item == null) return _Res.NotFoundId(Id);
      await repo.Delete(Id);
      await uow.Save();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Deletez));
    }
    return new OkObjectResult("Record Deleted Successfull");
  }

  public static async Task<IActionResult> Statusz<T>(IRepoGenericz<T> repo, IUOW_Infra uow, int Id, Status status)
    where T : class, IEntityAlpha
  {

    try
    {
      if (Id < 0) return _Res.NotFoundId(Id);
      if(!Enum.IsDefined(status)) return _Res.InvalidEnums(status.ToString());
      
      var item = await repo.Get(Id);

      if (item == null) return _Res.NotFoundId(Id);

      repo.UpdateStatus(item, status);
      await uow.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Statusz));
    }
  }

  public async static Task<IActionResult> GetsPaginatez<TEntity, TDtoSearch>(IRepoGenericz<TEntity> repo,  DtoRequestPage<TDtoSearch?> req)
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
      return _Res.CatchException(ex, nameof(GetsPaginatez));
    }
  }

  public async static Task<IActionResult> GetsPaginateOptionsz<TEntity, TDtoSearch>(IRepoGenericz<TEntity> repo, DtoRequestPage<TDtoSearch?> req)
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
      return _Res.CatchException(ex, nameof(GetsPaginateOptionsz));
    }
  }


}