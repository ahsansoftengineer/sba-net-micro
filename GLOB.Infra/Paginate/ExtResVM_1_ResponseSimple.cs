using System.Net;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;

public static partial class ExtResVM
{
  public static BaseVMSingle ToExtResVMSingle<TEntity>(this TEntity? item)
  where TEntity : class //, IEntityBase
  {
    var vm = new BaseVMSingle()
    {
      Record = item,
      Status = HttpStatusCode.OK
    };
    return vm;
  }
  // Maybe this doesn't reqired in future
  public static BaseVMMulti<TEntity> ToExtResVMMulti<TEntity>(this IList<TEntity>? list)
  // where TEntity : class, new()
  {
    var vm = new BaseVMMulti<TEntity>()
    {
      Records = list ?? new List<TEntity>(),
      Status = HttpStatusCode.OK
    };
    return vm;
  }
  public static BaseVMSelect<TKey> ToExtResVMSelect<TEntity, TKey>(this List<TEntity>? list)
  where TEntity : class, IEntityAlpha<TKey>
  {
    var vm = new BaseVMSelect<TKey>()
    {
      Records = new List<DtoSelect<TKey>>(),
      Status = HttpStatusCode.OK
    };
    if (list == null) return vm;

    var result = list.Select(x => new DtoSelect<TKey>
    {
      Id = x.Id,
      Name = x.Name
    }).ToList();
    vm.Records = result;
    return vm;
  }
}