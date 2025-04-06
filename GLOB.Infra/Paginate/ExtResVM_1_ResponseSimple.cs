using System.Net;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;

public static partial class ExtResponse
{
  public static BaseVMSingle<TEntity> ToExtResVMSingle<TEntity>(this TEntity? item)
  where TEntity : class //, IEntityBase
  {
    var vm = new BaseVMSingle<TEntity>()
    {
      Record = item,
      Status = HttpStatusCode.OK
    };
    return vm;
  }
  // Maybe this doesn't reqired in future
  public static BaseVMMulti<TEntity> ToExtResVMList<TEntity>(this IList<TEntity>? list)
  // where TEntity : class, new()
  {
    var vm = new BaseVMMulti<TEntity>()
    {
      Records = list ?? new List<TEntity>(),
      Status = HttpStatusCode.OK
    };
    return vm;
  }

  // public static BaseVMSelect<TKey> ToExtResVMListSelect<TEntity, TKey>(this List<TEntity>? list)
  //   where TEntity : class, IEntityAlpha<TKey>
  // {
  //   var vm = new BaseVMSelect<TKey>()
  //   {
  //     Records = new List<IEntityAlpha<TKey>>(),
  //     Status = HttpStatusCode.OK
  //   };
  //   if (list == null) return vm;

  //   vm.Records = list.Select(x =>(IEntityAlpha<TKey>)x).ToList();;
  //   return vm;
  // }
}