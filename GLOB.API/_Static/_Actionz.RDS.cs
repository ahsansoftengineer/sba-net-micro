using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using GLOB.Infra.Helper;
using GLOB.Infra.Repo;
using GLOB.Infra.UOW_Projectz;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Staticz;

public static class _Actionz
{
  public static async Task<IActionResult> Get<T>(this IRepoGenericz<T> repo, string NameOf, int Id, List<string>? Include)
    where T : class, IEntityAlpha
  {
    try
    {
      var single = await repo.Get(Id, Include);
      var result = single.ToExtResVMSingle();
      return new OkObjectResult(result);
    }
    catch(Exception ex)
    {
      return _Res.CatchException(ex, NameOf);
    }
  }

  public static async Task<IActionResult> Gets<T>(this IRepoGenericz<T> repo, string NameOf, List<string>? Include)
    where T : class, IEntityAlpha
  {
    try
    {
      var list = await repo.Gets(Include: Include);
      var result = list.ToExtResVMList();
      return new OkObjectResult(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, NameOf);
    }
  }
  
  public static async Task<IActionResult> Delete<T>(this IRepoGenericz<T> repo, IUOW_Infra uow, string NameOf, int Id)
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
      return _Res.CatchException(ex, NameOf);
    }
    return new OkObjectResult("Record Deleted Successfull");
  }

  public static async Task<IActionResult> Status<T>(IRepoGenericz<T> repo, IUOW_Infra uow, string NameOf, int Id, Status status)
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
      return new OkObjectResult(item);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, NameOf);
    }
  }

}