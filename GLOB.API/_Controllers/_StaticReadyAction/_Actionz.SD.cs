using GLOB.Domain.Base;
using GLOB.Domain.Enums;
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
  
  
  public static async Task<IActionResult> ToActionDelete<T>(this IRepoGenericz<T> repo, IUOW_Infra uow, int Id)
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
      return _Res.CatchException(ex, nameof(ToActionDelete));
    }
    return new OkObjectResult("Record Deleted Successfull");
  }

  public static async Task<IActionResult> ToActionStatus<T>(this IRepoGenericz<T> repo, IUOW_Infra uow, int Id, Status status)
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
      return _Res.CatchException(ex, nameof(ToActionStatus));
    }
  }

}